using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1.App.Dtos
{
    public class Order
    {
        public List<Product>? ShoppingCart { get; set; }
        public Locations location { get; set; }
        public Customer customer { get; set; }
    }
}
