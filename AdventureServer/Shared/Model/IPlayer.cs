using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IPlayer
        {
            string Name { get; }
            int PlayerID { get; }
            int CurrentLocationID { get; }
            IList<IItem> Inventory { get; }
            void AddItem(IItem item);
        }
    }
}
