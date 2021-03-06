﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    namespace Model
    {
        interface IItem
        {
            int ItemID { get; }
            string GetItemType { get; }
            bool ItemIsOfType(string type);
        }
    }
}
