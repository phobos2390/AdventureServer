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
            class RegionBuilder : IRegionBuilder
            {
                private int regionId;
                private string name;
                private IList<ILocation> locationsInRegion;

                private bool regionIdSet;
                private bool nameSet;
                private bool locationsSet;

                public RegionBuilder()
                {
                    this.regionId = 0;
                    this.name = "";
                    this.locationsInRegion = new List<ILocation>();

                    this.regionIdSet = false;
                    this.nameSet = false;
                    this.locationsSet = false;
                }

                public IRegion Build()
                {
                    if (this.regionIdSet && this.nameSet && this.locationsSet)
                    {
                        Region returnRegion = new Region(regionId, name, locationsInRegion);
                        for (int i = 0; i < this.locationsInRegion.Count; i++ )
                        {
                            this.locationsInRegion[i].Region = returnRegion;
                        }
                        return returnRegion;
                    }
                    else
                    {
                        return null;
                    }
                }

                public IRegionBuilder SetLocations(IList<ILocation> locations)
                {
                    this.locationsInRegion = locations;
                    this.locationsSet = true;
                    return this;
                }

                public IRegionBuilder AddLocation(ILocation location)
                {
                    this.locationsInRegion.Add(location);
                    this.locationsSet = true;
                    return this;
                }

                public IRegionBuilder SetRegionName(string name)
                {
                    this.name = name;
                    this.nameSet = true;
                    return this;
                }

                public IRegionBuilder SetRegionID(int id)
                {
                    this.regionId = id;
                    this.regionIdSet = true;
                    return this;
                }

                public IRegionBuilder SetValues(Tuple<int, string> values)
                {
                    this.SetRegionID(values.Item1);
                    this.SetRegionName(values.Item2);
                    return this;
                }
            }
        }
    }
}