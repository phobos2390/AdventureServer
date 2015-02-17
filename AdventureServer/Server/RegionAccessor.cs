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
        class RegionAccessor : IRegionAccessor
        {
            IDatabase database;
            IRegionProcedure procedure;
            IModelMain model;

            public RegionAccessor(IDatabase database, Shared.Model.IModelMain model)
            {
                this.database = database;
                this.procedure = new RegionProcedure(database);
                this.model = model;
            }

            public IRegion GetRegion(int regionId)
            {
                IRegionBuilder regionBuilder = model.BuilderFactory.CreateRegionBuilder();
                regionBuilder.SetValues(this.procedure.GetRegionBasicInfo(regionId));
                regionBuilder.SetLocations(
                    this.database.Access.Location.GetLocations(
                        regionId,
                        this.procedure.GetAllLocationsForRegion(regionId)));
                return regionBuilder.Build();
            }

            public void AddRegion(IRegion addRegion)
            {
                this.procedure.AddRegionBasicInfo(new Tuple<int, string>(addRegion.RegionID, addRegion.Name));
                for (int i = 0; i < addRegion.LocationsInRegion.Count; i++)
                {
                    this.database.Access.Location.AddLocation(addRegion.LocationsInRegion[i]);
                }
            }
        }
    }
}
