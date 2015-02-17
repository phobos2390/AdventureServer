using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    namespace Database
    {
        public interface IDatabaseAccessor
        {
            IRegionAccessor Region { get; }
            ILocationAccessor Location { get; }
            void ClearDatabase();
        }
    }
}
