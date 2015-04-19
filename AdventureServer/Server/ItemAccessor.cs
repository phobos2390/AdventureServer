using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Server
{
    class ItemAccessor : IItemAccessor
    {
        public IItem GetFromItemIndex(int index)
        {
            return null;
        }

        public void AddItem(IItem item)
        {
            
        }

        public void PickUpItem(IItem item, IPlayer player)
        {

        }
    }
}
