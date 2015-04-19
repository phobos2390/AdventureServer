using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IEdgeBuilder
        {
            IEdgeBuilder SetValues(object tuple);
            IEdge Build();
        }
    }
}
