using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model.Builders;

namespace Shared
{
    namespace Model
    {
        public interface IModelBuilderFactory
        {
            ILocationBuilder CreateLocationBuilder(bool inCurrentRegion);
            IRegionBuilder CreateRegionBuilder();
        }
    }
}
