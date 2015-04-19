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
            private IList<Tuple<int, IEdge>> adjacencies;
            private IList<IItem> items;

            public OutOfRegionLocation(int regionId, int locationId, string name)
                :base(regionId, locationId, name)
            {
                adjacencies = new List<Tuple<int, IEdge>>();
                items = new List<IItem>();
            }

            public IList<Tuple<int,IEdge>> Adjacencies
            {
                get { return adjacencies; }
            }
        }
    }
}
