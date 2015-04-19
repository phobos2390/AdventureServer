using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    class StandardEdge : IEdge
    {
        private int id;

        public StandardEdge(int id)
        {
            this.id = id;
        }

        public bool CanPass(IPlayer givenPlayer)
        {
            return true;
        }

        public int ID
        {
            get { return this.id; }
        }
    }
}
