using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1.App
{
    public class Inventory
    {
        public Items item;
        public string itemDescription;
        public string itemPrice;
        public int quantityAvailable;
        public Inventory(Items items, string itemDescription, string itemPrice, int quantityAvailable)
        {
            item = items;
            this.itemDescription = itemDescription;
            this.itemPrice = itemPrice.ToString();
            this.quantityAvailable = quantityAvailable;
        }
    }
}
