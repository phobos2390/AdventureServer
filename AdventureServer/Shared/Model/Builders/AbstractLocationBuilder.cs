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
            abstract class AbstractLocationBuilder : ILocationBuilder
            {
                private int regionId;
                private int locationId;
                private string name;

                private bool regionIdSet;
                private bool locationIdSet;
                private bool nameSet;

                public AbstractLocationBuilder()
                {
                    this.regionId = 0;
                    this.locationId = 0;
                    this.name = "";

                    this.regionIdSet = false;
                    this.locationIdSet = false;
                    this.nameSet = false;
                }

                protected bool RegionIdSet
                {
                    get { return this.regionIdSet; }
                }

                protected bool LocationIdSet
                {
                    get { return this.locationIdSet; }
                }

                protected bool NameSet
                {
                    get { return this.nameSet; }
                }

                protected int RegionId 
                { 
                    get { return this.regionId; } 
                }

                protected int LocationId
                {
                    get { return this.locationId; }
                }

                protected string Name
                {
                    get { return this.name; }
                }

                public ILocationBuilder SetName(string name)
                {
                    this.name = name;
                    this.nameSet = true;
                    return this;
                }

                public ILocationBuilder SetLocationId(int locationId)
                {
                    this.locationId = locationId;
                    this.locationIdSet = true;
                    return this;
                }

                public ILocationBuilder SetRegionId(int regionId)
                {
                    this.regionId = regionId;
                    this.regionIdSet = true;
                    return this;
                }

                public ILocationBuilder SetValues(Tuple<int, int, string> values)
                {
                    this.SetRegionId(values.Item1);
                    this.SetLocationId(values.Item2);
                    this.SetName(values.Item3);
                    return this;
                }

                public abstract ILocation Build();

                public abstract ILocationBuilder SetAdjacencies(IList<int> adjacencies);

                public abstract ILocationBuilder AddAdjacency(int locationId);

                public abstract ILocationBuilder SetItems(IList<IItem> items);

                public abstract ILocationBuilder AddItem(IItem item);
            }
        }
    }
}
