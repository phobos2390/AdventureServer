using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        class IItemBuilder
        {
            IItemBuilder SetItemID(int itemId);
            IItemBuilder SetValues(Tuple values);
            IItem Build();
        }
    }
}
