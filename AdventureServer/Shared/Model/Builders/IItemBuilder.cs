using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IItemBuilder
        {
            IItemBuilder SetItemID(int itemId);
            IItemBuilder SetValues(object values);
            IItem Build();
        }
    }
}
