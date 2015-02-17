using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Server
{
    namespace Database
    {
        public interface ILocationAccessor
        {
            ILocation GetLocation(int currentRegionId, int locationId);
            IList<ILocation> GetLocations(int currentRegionId, IList<Tuple<int, int, string>> locationList);
            void AddLocation(ILocation location);
        }
    }
}
