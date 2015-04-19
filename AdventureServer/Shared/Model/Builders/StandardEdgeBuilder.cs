using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model.Builders
{
    class StandardEdgeBuilder : IEdgeBuilder
    {
        private int id;

        public IEdgeBuilder SetValues(object tuple)
        {
            this.id = ((Tuple<int>)tuple).Item1;
            return this;
        }

        public IEdge Build()
        {
            return new StandardEdge(this.id);
        }
    }
}
