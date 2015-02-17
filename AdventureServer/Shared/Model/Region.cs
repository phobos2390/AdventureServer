using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        public class Region : IRegion
        {
            private string name;
            private int regionID;
            private IList<ILocation> locations;

            public Region(int regionID, string name, IList<ILocation> locations)
            {
                this.regionID = regionID;
                this.name = name;
                this.locations = locations;
            }
            
            public string Name
            {
                get { return this.name; }
            }

            public int RegionID
            {
                get { return this.regionID; }
            }

            public bool IsInRegion(ILocation location)
            {
                return RegionID == location.RegionID;
            }

            public ILocation GetLocation(int locationId)
            {
                for (int i = 0; i < this.locations.Count; i++)
                {
                    if (this.locations[i].LocationID == locationId)
                    {
                        return this.locations[i];
                    }
                }
                return null;
            }

            public IList<ILocation> Adjacencies(ILocation location)
            {
                IList<ILocation> returnList = new List<ILocation>();
                IList<int> locationAdjacencies = location.Adjacencies;
                for (int i = 0; i < locationAdjacencies.Count; i++)
                {
                    returnList.Add(GetLocation(locationAdjacencies[i]));
                }
                return returnList;
            }

            public IList<ILocation> Adjacencies(int locationId)
            {
                return Adjacencies(GetLocation(locationId));
            }

            public IList<ILocation> LocationsInRegion
            {
                get { return this.locations; }
            }

            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Region ID: ").Append(this.RegionID).Append("\n");
                builder.Append("Region Name: ").Append(this.Name).Append("\n");
                builder.Append("Locations:\n");
                foreach (ILocation location in this.LocationsInRegion)
                {
                    builder.Append("\tLocation ID: ").Append(location.LocationID).Append("\n");
                    builder.Append("\tLocation Name: ").Append(location.Name).Append("\n");
                    builder.Append("\tAdjacentLocations\n");
                    IList<ILocation> adjacentLocations = this.Adjacencies(location);
                    foreach (ILocation adjacentLocation in adjacentLocations)
                    {
                        builder.Append("\t\t-").Append(adjacentLocation.Name).Append("\n");
                    }
                }
                return builder.ToString();
            }
        }
    }
}
