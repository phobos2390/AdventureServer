using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Server
{
    interface IItemAccessor
    {
        IItem GetFromItemIndex(int index);
        void AddItem(IItem item);
        void PickUpItem(IItem item, IPlayer player);
    }
}
