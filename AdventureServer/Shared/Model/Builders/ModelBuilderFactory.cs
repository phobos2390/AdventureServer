using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        namespace Builders
        {
            public class ModelBuilderFactory : IModelBuilderFactory
            {
                public ILocationBuilder CreateLocationBuilder(bool inCurrentRegion)
                {
                    if (inCurrentRegion)
                    {
                        return new InRegionLocationBuilder();
                    }
                    else
                    {
                        return new OutOfRegionLocationBuilder();
                    }
                }

                public IRegionBuilder CreateRegionBuilder()
                {
                    return new RegionBuilder();
                }
            }
        }
    }
}
