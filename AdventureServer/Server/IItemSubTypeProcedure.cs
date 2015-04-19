using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;

namespace Server.Database
{
    interface IItemSubTypeProcedure
    {
        object GetItemValuesFromID(int id);
        void AddItem(object itemValues);
        bool IsOfSubtype(string type);
    }
}
