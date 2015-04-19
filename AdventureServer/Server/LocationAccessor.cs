using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;
using Shared.Model.Builders;

namespace Server
{
    namespace Database
    {
        public class LocationAccessor : ILocationAccessor
        {
            private ILocationProcedure procedure;
            private IModelMain model;
            private IDatabase database;

            public LocationAccessor(IDatabase database, IModelMain model)
            {
                this.database = database;
                this.procedure = new LocationProcedure(database);
                this.model = model;
            }

            public ILocation GetLocation(int currentRegionId, int locationId)
            {
                Tuple<int,int,string> returnTuple = this.procedure.GetLocation(locationId);
                ILocationBuilder builder = this.model.BuilderFactory.CreateLocationBuilder(returnTuple.Item1 == currentRegionId);
                builder.SetValues(returnTuple);
                IList<Tuple<int, int>> adjacency = this.procedure.GetAdjacencies(locationId);
                builder.SetAdjacencies(this.database.Access.Edge.GetEdges(adjacency));
                return builder.Build();
            }

            public IList<ILocation> GetLocations(int currentRegionId, IList<Tuple<int, int, string>> locationListData)
            {
                IList<ILocation> locationList = new List<ILocation>();
                for (int i = 0; i < locationListData.Count; i++)
                {
                    locationList.Add(GetLocation(currentRegionId, locationListData[i].Item2));
                }
                return locationList;
            }

            public void AddLocation(ILocation location)
            {
                this.procedure.AddLocation(new Tuple<int, int, string>(location.RegionID, location.LocationID, location.Name));
                IList<Tuple<int,IEdge>> adjacencyList = location.Adjacencies;
                for (int i = 0; i < adjacencyList.Count; i++)
                {
                    this.procedure.SetAdjacent(new Tuple<int, int, int>(location.LocationID, adjacencyList[i].Item1, adjacencyList[i].Item2));
                }
            }
        }
    }
}
