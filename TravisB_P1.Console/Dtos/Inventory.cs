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
        public Items Item { get; set; }
        public string? ItemDescription { get; set; }
        public string? ItemPrice { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
