using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        abstract class AbstractLocation : ILocation
        {
            private int regionId;
            private int locationId;
            private string name;
            private IRegion region;
            
            public AbstractLocation(int regionId, int locationId, string name)
            {
                this.regionId = regionId;
                this.locationId = locationId;
                this.name = name;
            }

            public string Name
            {
                get { return this.name; }
            }

            public int LocationID
            {
                get { return this.locationId; }
            }

            public int RegionID
            {
                get { return this.regionId; }
            }

            public IRegion Region
            {
                set { this.region = value; }
            }

            public IList<ILocation> AdjacentLocations
            {
                get
                {
                    return this.region.Adjacencies(this.LocationID);
                }
            }
        }
    }
}
