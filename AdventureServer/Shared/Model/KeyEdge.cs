using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    class KeyEdge : IEdge
    {
        private int id;
        private IItem keyItem;

        public KeyEdge(IItem keyItem, int id)
        {
            this.id = id;
            this.keyItem = keyItem;
        }

        public bool CanPass(IPlayer givenPlayer)
        {
            return givenPlayer.Inventory.Contains(this.keyItem);
        }

        public int ID
        {
            get { return this.id; }
        }
    }
}
