using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Data.SqlClient;

namespace TravisB_P0
{
    public class Order : IOrder
    {
        private List<Product>? ShoppingCart;
        Locations location;

        //constructors
        public Order(List<Product> cart, Locations location)
        {
            this.ShoppingCart = cart;
            this.location = location;
        }

        public static void CheckingInventory(Locations location)
        {
            int totalAvailable = (int)DBInterface.GettingInventory(location).Rows[0]["Quantity"];
            Console.WriteLine(totalAvailable);
        }

        public bool AddToCart()
        {
            Console.WriteLine("\nPlease specify what you would like to order, or enter done if done ordering");
            string selection = Console.ReadLine()!;

            Console.WriteLine($"__{selection}__");

            if (selection == "done")
            {
                return true;
            }
            else if (selection == "Cheese" || selection == "Pepperoni" || selection == "Hawaiian" || selection == "Alfredo" || selection == "Deluxe")
            {
                Products productSelection = (Products)Enum.Parse(typeof(Products), selection);

                Console.WriteLine("How many would you like to order?\n");
                string number = Console.ReadLine()!;
                bool isNumber = int.TryParse(number, out int quantity);
                if (isNumber)
                {
                    if (quantity > 20)
                    {
                        Console.WriteLine("I'm sorry, we don't support orders of more than 20 items of any kind due to demand");
                    }
                    Product thisProduct = new(productSelection, quantity);
                    ShoppingCart!.Add(thisProduct);
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
        public void FinalizeOrder(Order order, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddToHistory(Order order)
        {
            throw new NotImplementedException();
        }

        public float Total(List<Product> cart)
        {
            foreach (Product item in ShoppingCart!)
            {
                throw new NotImplementedException();
            }
            return 0;
        }
    }
}