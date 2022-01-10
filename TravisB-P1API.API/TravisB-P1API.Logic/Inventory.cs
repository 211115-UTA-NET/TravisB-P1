namespace TravisB_P1API.Logic
{
    public class Inventory
    {
        public Items item;
        public string itemDescription;
        public string itemPrice;
        public int quantityAvailable;
        public Inventory(Items items, string itemDescription, string itemPrice, int quantityAvailable)
        {
            item = items;
            this.itemDescription = itemDescription;
            this.itemPrice = itemPrice.ToString();
            this.quantityAvailable = quantityAvailable;
        }

        //for serializer
        public Inventory()
        {

        }
    }
}
