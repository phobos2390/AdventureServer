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
        public interface IRegionAccessor
        {
            IRegion GetRegion(int regionId);
            void AddRegion(IRegion addRegion);
        }
    }
}
