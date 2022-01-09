
namespace TravisB_P1.App
{
    public class Product
    {
        public Items productName{ get; set; }
        public int quantity { get; set; }

        public Product(Items Item, int quantity)
        {
            this.productName = Item;
            this.quantity = quantity;
        }

        
    }
}
