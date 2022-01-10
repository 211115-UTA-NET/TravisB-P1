using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisB_P1.App;

namespace TravisB_P0.Dtos
{
    public class Inventory
    {
        public Items item { get; set; }
        public string itemDescription { get; set; }
        public string itemPrice { get; set; }
        public int quantityAvailable { get; set; }
    }
}
