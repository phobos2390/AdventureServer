using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        public interface IRegion
        {
            String Name { get; }
            int RegionID { get; }
            bool IsInRegion(ILocation location);
            ILocation GetLocation(int locationId);
            IList<ILocation> Adjacencies(ILocation location);
            IList<ILocation> Adjacencies(int locationId);
            IList<ILocation> LocationsInRegion { get; }
        }
    }
}
