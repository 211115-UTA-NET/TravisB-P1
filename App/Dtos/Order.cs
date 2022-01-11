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
        public Locations Location { get; set; }
        public Customer? Customer { get; set; }
    }
}
