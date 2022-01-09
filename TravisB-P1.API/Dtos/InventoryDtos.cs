using System.ComponentModel.DataAnnotations;

namespace TravisB_P1.API.Dtos
{
    public class InventoryDtos
    {
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Price { get; set; }
        [Required]
        public string? ItemDescription { get; set; }
        [Required]
        public int NumberAvailable { get; set; }
    }
}
