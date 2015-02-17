using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IPlayerBuilder
        {
            IPlayerBuilder SetID(int id);
            IPlayerBuilder SetCurrentLocationID(int id);
            IPlayerBuilder SetName(string name);
            IPlayerBuilder SetValues(Tuple<int, int, string> values);
            IPlayerBuilder SetInventory(IList<IItem> inventory);
            IPlayerBuilder AddItem(IItem addItem);
            IPlayer Build();
        }
    }
}
