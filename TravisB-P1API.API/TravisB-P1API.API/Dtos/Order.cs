using System.ComponentModel.DataAnnotations;
using TravisB_P1.Logic;

namespace TravisB_P1API.API.Dtos
{
    public class Order
    {
        [Required]
        public DateTimeOffset OrderDate { get; set; }
        [Required]
        public List<Product>? ShoppingCart { get; set; }
        [Required]
        public Locations location { get; set; }
        [Required]
        public CustomerDtos customer { get; set; }
    }
}