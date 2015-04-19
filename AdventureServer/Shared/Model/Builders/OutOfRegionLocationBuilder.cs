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
            class OutOfRegionLocationBuilder : AbstractLocationBuilder
            {
                public override ILocation Build()
                {
                    if (this.RegionIdSet
                        && this.LocationIdSet
                        && this.NameSet)
                    {
                        return new OutOfRegionLocation(
                            this.RegionId,
                            this.LocationId,
                            this.Name
                            );
                    }
                    else
                    {
                        return null;
                    }
                }

                public override ILocationBuilder SetAdjacencies(IList<Tuple<int,IEdge>> adjacencies)
                {
                    return this;
                }

                public override ILocationBuilder AddAdjacency(int locationId, IEdge edge)
                {
                    return this;
                }
            }
        }
    }
}
