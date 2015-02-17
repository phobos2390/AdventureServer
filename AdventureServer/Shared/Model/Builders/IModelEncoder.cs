using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        public interface IModelEncoder
        {
            void AddRegion(IRegion region);
            void ClearDatabase();
        }
    }
}
