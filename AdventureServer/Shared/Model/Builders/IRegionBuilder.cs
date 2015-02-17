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
            public interface IRegionBuilder
            {
                IRegion Build();
                IRegionBuilder SetLocations(IList<ILocation> locations);
                IRegionBuilder AddLocation(ILocation location);
                IRegionBuilder SetRegionName(string name);
                IRegionBuilder SetRegionID(int id);
                IRegionBuilder SetValues(Tuple<int, string> values);
            }
        }
    }
}
