using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        public interface ILocation
        {
            String Name { get; }
            int LocationID { get; }
            int RegionID { get; }
            IRegion Region { set; }
            IList<Tuple<int,IEdge>> Adjacencies { get; }
            IList<Tuple<ILocation,IEdge>> AdjacentLocations { get; }
            IList<IItem> Items { get; }
        }
    }
}
