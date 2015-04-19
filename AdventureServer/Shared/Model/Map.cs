using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shared.Model
{
    class Map:IItem
    {
        private int itemId;
        private string itemType;
        private Image mapImage;
        private int regionID;

        public Map(int itemId, Image mapImage, int regionID)
        {
            this.itemId = itemId;
            this.mapImage = mapImage;
            this.regionID = regionID;
        }

        public int RegionID
        {
            get { return this.regionID; }
        }
        
        public Image MapImage
        {
            get { return this.mapImage; }
        }

        public int ItemID
        {
            get { return this.itemId; }
        }

        public string GetItemType
        {
            get { return this.itemType; }
        }

        public bool ItemIsOfType(string type)
        {
            return type == this.itemType;
        }
    }
}
