using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model.Builders
{
    class KeyEdgeBuilder : IEdgeBuilder
    {
        private IItem neededKeyItem;
        private int id;

        public IEdgeBuilder SetValues(object tuple)
        {
            Tuple<int,IItem> tup = (Tuple<int,IItem>)tuple;
            this.id = tup.Item1;
            this.neededKeyItem = tup.Item2;
            return this;
        }

        public IEdge Build()
        {
            return new KeyEdge(this.neededKeyItem,this.id);
        }
    }
}
