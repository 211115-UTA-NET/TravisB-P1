using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TravisB_P1
{
    public class Product
    {
        public Products productName{ get; set; }
        public int quantity { get; set; }

        public Product(Products Item, int quantity)
        {
            this.productName = Item;
            this.quantity = quantity;
        }

        
    }
}
