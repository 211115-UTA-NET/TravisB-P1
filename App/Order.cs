using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using TravisB_P1.App.Dtos;

namespace TravisB_P1.App
{
    public class Order : IOrder
    {
        public List<Product>? shoppingCart { get; set; }
        public Locations location { get; set; }


        //constructors
        public Order(List<Product> cart, Locations location)
        {
            this.shoppingCart = cart;
            this.location = location;
        }


        public bool AddToCart()
        {
            Console.WriteLine("\nPlease specify what you would like to order, or enter done if done ordering");
            string selection = Console.ReadLine()!;


            if (selection == "done")
            {
                return true;
            }
            else if (selection == "Cheese" || selection == "Pepperoni" || selection == "Hawaiian" || selection == "Alfredo" || selection == "Deluxe")
            {
                Items productSelection = (Items)Enum.Parse(typeof(Items), selection);

                Console.WriteLine("How many would you like to order?\n");
                string number = Console.ReadLine()!;
                bool isNumber = int.TryParse(number, out int quantity);
                if (isNumber)
                {
                    if (quantity > totalAvailable)
                    {
                        Console.WriteLine("I'm sorry, we do not have enough available to complete your order.");
                    }
                    if (quantity > 20)
                    {
                        Console.WriteLine("I'm sorry, we don't support orders of more than 20 items of any kind due to demand");
                    }
                    Product thisProduct = new(productSelection, quantity);
                    shoppingCart!.Add(thisProduct);
                }
                else
                {
                    Console.WriteLine("Please enter a valid quantity");
                }
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand that please try again");
            }
            return false;
        }

        public float Total(List<Product> cart)
        {
                throw new NotImplementedException();
        }
    }
}