using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        class InRegionLocation : AbstractLocation
        {
            private IList<Tuple<int,IEdge>> adjacencies;
            private IList<IItem> items;
            
            public InRegionLocation(int regionID, int locationId, string name, IList<Tuple<int,IEdge>> adjacencies, IList<IItem> items)
                :base(regionID,locationId,name)
            {
                this.adjacencies = adjacencies;
                this.items = items;
            }

            public IList<Tuple<int,IEdge>> Adjacencies
            {            
                get 
                { 
                    return this.adjacencies;
                }
            }

            public IList<IItem> Items
            {
                get
                {
                    return this.items;
                }
            }
        }
    }
}
