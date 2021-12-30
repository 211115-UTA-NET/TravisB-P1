using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Data.SqlClient;

namespace TravisB_P0
{

    public class Program
    {
        static void Main()
        {

            Locations locationChoice = new Locations();

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

            DBInterface.GettingMenu();

            bool done = false;
            List<Product> cart = new();

            Order thisOrder = new(cart, locationChoice);
            while (done != true)
            {
                done = thisOrder.AddToCart();
            }

            Customer thisCustomer = new(name!);
            thisOrder.FinalizeOrder(thisOrder, thisCustomer);
        }
    }
}
