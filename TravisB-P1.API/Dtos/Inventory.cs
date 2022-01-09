using System.ComponentModel.DataAnnotations;

namespace TravisB_P1.API.Dtos
{
    public class Inventory
    {
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public string? ItemDescription { get; set; }
        public int NumberAvailable { get; set; }
    }
}
