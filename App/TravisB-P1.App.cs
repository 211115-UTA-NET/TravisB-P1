using System.Net.Http.Json;
using System.Text.Json;
using TravisB_P1.App.Dtos;

namespace TravisB_P1.App
{

    public class TravisBP1
    {
        public async static Task Main()
        {
            bool madeChoice = false;
            string entry = "";
            while (madeChoice != true)
            {
                Console.WriteLine("Hello, what would you like to do today?");
                Console.WriteLine("1) Order \t 2) View History \t 3) Exit");
                Console.WriteLine("______________________________________________");
                entry = Console.ReadLine()!;
                entry = entry!.ToLower();
                if (entry == "order" || entry == "view history" || entry == "exit")
                {
                    madeChoice = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }


            Uri server = new("https://localhost:7202");


            switch (entry)
            {
                case "order":

                    Locations locationChoice = Order.GetLocation();
                    // getting menu (with total available) goes here
                    IOrderService orderService1 = new OrderService(server);
                    orderService1.GetInventoryAsync(locationChoice);


                    List<Product> cart = new();

                    Order thisOrder = new(cart, locationChoice);
                    thisOrder.AddToCartAsync(locationChoice);


                    //getting Customer name
                    string name = "";
                    bool gotName = false;
                    do
                    {
                        if (name == "" || name == null)
                        {
                            Console.WriteLine("Please enter your name for our records");
                            name = Console.ReadLine()!;
                        }
                        else
                        {
                            gotName = true;
                        }
                    } while (gotName != true);

                    Customer thisCustomer = new();
                    thisCustomer.Name = name;
                    break;

                case "view history":
                    break;

                case "exit":
                    break;
                    
            }

            
        }
    }
}
