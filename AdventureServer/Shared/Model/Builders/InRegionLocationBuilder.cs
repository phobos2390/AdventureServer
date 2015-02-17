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
            class InRegionLocationBuilder : AbstractLocationBuilder
            {
                private IList<int> adjacencies;
                private IList<IItem> items;

                private bool adjacenciesSet;
                private bool itemsSet;

                public InRegionLocationBuilder():base()
                {
                    this.adjacencies = new List<int>();

                    this.adjacenciesSet = false;
                    this.itemsSet = false;
                }

                public override ILocation Build()
                {
                    if (this.RegionIdSet
                        && this.LocationIdSet
                        && this.NameSet
                        && this.adjacenciesSet
                        && this.itemsSet)
                    {
                        return new InRegionLocation(
                            this.RegionId,
                            this.LocationId,
                            this.Name,
                            this.adjacencies,
                            this.items
                            );
                    }
                    else
                    {
                        return null;
                    }
                }

                public override ILocationBuilder SetAdjacencies(IList<int> adjacencies)
                {
                    this.adjacencies = adjacencies;
                    this.adjacenciesSet = true;
                    return this;
                }

                public override ILocationBuilder AddAdjacency(int locationId)
                {
                    this.adjacencies.Add(locationId);
                    this.adjacenciesSet = true;
                    return this;
                }

                public override ILocationBuilder SetItems(IList<IItem> items)
                {
                    throw new NotImplementedException();
                }

                public override ILocationBuilder AddItem(IItem item)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
