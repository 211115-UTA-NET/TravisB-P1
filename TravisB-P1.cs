using TravisB_P1.API;

namespace TravisB_P1
{

    public class Program
    {
        static void Main()
        {
            bool madeChoice = false;
            string entry = "";
            while (madeChoice != true)
            {
                Console.WriteLine("Hello, what would you like to do today?");
                Console.WriteLine("1) Order \t 2) View History \t 3) Exit");
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
            switch (entry)
            {
                case "order":

                    Locations locationChoice = new();

                    bool gotLocation = false;

                    while (gotLocation != true)
                    {
                        Console.WriteLine("What location would you like to pick up at?");
                        string location = Console.ReadLine()!;
                        if (location == null)
                        {
                            Console.WriteLine("Please enter a location");
                        }
                        else if (location == "Hopkins" || location == "Robbinsdale" || location == "Plymouth" || location == "Minneapolis")
                        {
                            locationChoice = (Locations)Enum.Parse(typeof(Locations), location);
                            gotLocation = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, we don't have a shop there. Eligible locations are Minneapolis, Robbinsdale, Hopkins, and Plymouth");
                        }
                    }

                    DBInterface.GettingMenu();

                    bool done = false;
                    List<Product> cart = new();

                    Order thisOrder = new(cart, locationChoice);
                    while (done != true)
                    {
                        done = thisOrder.AddToCart();
                    }
                    break;

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


                    Customer thisCustomer = new(name!);
                    thisOrder.FinalizeOrder(thisOrder, thisCustomer);

                case "view history":
                    break;

                case "exit":
                    break;
                    
            }

            
        }
    }
}
