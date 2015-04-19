using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Shared.Model;

namespace Server.Database
{
    class ItemAccessor : IItemAccessor
    {
        private ItemProcedure baseItemProcedure;
        private IDatabase database;
        private IModelMain model;
        private IList<IItemSubTypeProcedure> itemSubTypeProcedures;

        public ItemAccessor(IDatabase database, IModelMain model)
        {
            this.database = database;
            this.model = model;
            this.baseItemProcedure = new ItemProcedure(database);
            this.itemSubTypeProcedures = new List<IItemSubTypeProcedure>();
            this.itemSubTypeProcedures.Add(new KeyItemProcedure(database));
        }

        private IItemSubTypeProcedure getProcedureFromType(string type)
        {
            IEnumerable<IItemSubTypeProcedure> retEnumerable = from proc in this.itemSubTypeProcedures
                                                               where proc.IsOfSubtype(type) == true
                                                               select proc;
            return retEnumerable.First();
        }

        public IItem GetFromItemIndex(int index)
        {
            string type = this.baseItemProcedure.GetItemType(index);
            IItemBuilder builder = this.model.BuilderFactory.CreateItemBuilder(type);
            builder.SetItemID(index);
            builder.SetValues(this.getProcedureFromType(type).GetItemValuesFromID(index));
            return builder.Build();
        }

        private object getItemValues(IItem item)
        {
            switch (item.GetItemType)
            {
                case "Key":
                    KeyItem encodeItem = (KeyItem)item;
                    return Tuple.Create<int, string, string>(encodeItem.ItemID, encodeItem.Name, encodeItem.Text);
                case "Map":
                    Map encodeMap = (Map)item;
                    return Tuple.Create<int, Image, int>(encodeMap.ItemID, encodeMap.MapImage, encodeMap.RegionID);
                default:
                    return null;
            }
        }

        public void AddItem(IItem item)
        {
            this.getProcedureFromType(item.GetItemType).AddItem(this.getItemValues(item));
        }

        public void PickUpItem(IItem item, IPlayer player)
        {
            this.baseItemProcedure.AddItemToInventory(item.ItemID, player.PlayerID);
        }
    }
}
