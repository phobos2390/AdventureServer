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
                public IItemBuilder CreateItemBuilder(string itemType)
                {
                    switch (itemType)
                    {
                        default:
                            return null;
                    }
                }

                public IEdgeBuilder CreateEdgeBuilder(string edgeType)
                {
                    switch (edgeType)
                    {
                        case "Key":
                            return new KeyEdgeBuilder();
                        default:
                            return new StandardEdgeBuilder();
                    }
                }

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
