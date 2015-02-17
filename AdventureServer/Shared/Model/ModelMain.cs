using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Database;
using Shared.Model.Builders;

namespace Shared
{
    namespace Model
    {
        public class ModelMain : IModelMain
        {
            private int defaultLocationID;
            private int defaultRegionID;
            private int currentLocationID;
            private int currentRegionID;
            private IRegion currentRegion;
            private IModelBuilderFactory builderFactory;
            private IModelLoader loader;
            private IModelEncoder encoder;
            private IDatabase database;

            public ModelMain()
            {
                this.defaultLocationID = 1;
                this.defaultRegionID = 1;
                this.currentLocationID = this.defaultLocationID;
                this.currentRegionID = this.defaultRegionID;
                this.database = new SQLServerDatabase(this);
                this.loader = new ModelLoader(this.database);
                this.builderFactory = new ModelBuilderFactory();
                this.encoder = new ModelEncoder(database);
            }

            public IModelBuilderFactory BuilderFactory
            {
                get { return this.builderFactory; }
            }

            public IModelLoader Loader
            {
                get { return this.loader; }
            }

            public IModelEncoder Encoder
            {
                get { return this.encoder; }
            }

            public ILocation CurrentLocation
            {
                get
                {
                    if (this.currentRegion == null)
                    {
                        this.currentRegion = this.Loader.GetRegion(this.currentRegionID);
                    }
                    this.CurrentLocation = this.currentRegion.GetLocation(this.currentLocationID);
                    return this.currentRegion.GetLocation(this.currentLocationID);
                }
                set
                {
                    this.currentLocationID = value.LocationID;
                    if (currentRegionID != value.RegionID)
                    {
                        this.currentRegion = this.loader.GetRegion(value.RegionID);
                        this.currentRegionID = currentRegion.RegionID;
                    }
                }
            }


            public IList<ILocation> AdjacentLocations
            {
                get 
                { 
                    return this.currentRegion.Adjacencies(this.currentLocationID); 
                }
            }
        }
    }
}
