using System.ComponentModel.DataAnnotations;

namespace TravisB_P1.API.Dtos
{
    public class OrderDtos
    {
        [Required]
        public List<Product>? ShoppingCart { get; set; }
        [Required]
        public Locations location { get; set; }
        [Required]
        public CustomerDtos customer { get; set; }
    }
}
