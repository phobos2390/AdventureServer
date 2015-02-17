using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        class OutOfRegionLocation : AbstractLocation
        {
            private IList<int> adjacencies;
            private IList<IItem> items;

            public OutOfRegionLocation(int regionId, int locationId, string name)
                :base(regionId, locationId, name)
            {
                adjacencies = new List<int>();
                items = new List<IItem>();
            }

            public IList<int> Adjacencies
            {
                get { return adjacencies; }
            }
        }
    }
}
