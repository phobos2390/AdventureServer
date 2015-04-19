using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    class KeyItem : IItem
    {
        private int itemId;
        private string name;
        private string text;
        private string type;

        public KeyItem(int itemId, string name, string text)
        {
            this.itemId = itemId;
            this.name = name;
            this.text = text;
            this.type = "Key";
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Text
        {
            get { return this.text; }
        }

        public int ItemID
        {
            get { return this.itemId; }
        }

        public string GetItemType
        {
            get { return this.type; }
        }

        public bool ItemIsOfType(string type)
        {
            return type == this.type;
        }
    }
}
