using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1API.Logic
{
    public class Order
    {
        public List<Product>? shoppingCart { get; set; }
        public Locations location { get; set; }
    }
}
