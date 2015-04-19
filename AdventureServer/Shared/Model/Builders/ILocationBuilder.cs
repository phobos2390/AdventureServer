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
            public interface ILocationBuilder
            {
                ILocation Build();
                ILocationBuilder SetName(string name);
                ILocationBuilder SetLocationId(int locationId);
                ILocationBuilder SetRegionId(int regionId);
                ILocationBuilder SetValues(Tuple<int, int, string> values);
                ILocationBuilder SetAdjacencies(IList<Tuple<int,IEdge>> adjacencies);
                ILocationBuilder AddAdjacency(int locationId,IEdge edgeType);
                ILocationBuilder SetItems(IList<IItem> items);
                ILocationBuilder AddItem(IItem item);
            }
        }
    }
}
