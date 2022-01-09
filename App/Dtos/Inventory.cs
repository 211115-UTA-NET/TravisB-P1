using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisB_P1.App.Dtos
{
    public class Inventory
    {
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public string? ItemDescription { get; set; }
        public int NumberAvailable { get; set; }
    }
}
