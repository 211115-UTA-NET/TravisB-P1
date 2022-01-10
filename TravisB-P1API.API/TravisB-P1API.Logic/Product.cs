using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1API.Logic
{
    public class Product
    {
        public Items productName { get; set; }
        public int quantity { get; set; }

        public Product(Items Item, int quantity)
        {
            this.productName = Item;
            this.quantity = quantity;
        }
    }
}
