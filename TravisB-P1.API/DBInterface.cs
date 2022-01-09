using System.Data.SqlClient;
using System.Data;

namespace TravisB_P1.API
{
    public class DBInterface
    {


        public static void GettingMenu()
        {
            //Connection and database interface
            string connectionString = File.ReadAllText("C:/Users/Owner/Revature/connectionString.txt");
            using SqlConnection connection = new(connectionString);
            string commandText = "SELECT Items.ItemName, ItemDescrip, ItemPrice FROM Items;";
            connection.Open();
            SqlDataAdapter menuGrabber = new(commandText, connection);
            DataTable menu = new();
            menuGrabber.Fill(menu);
            menu.TableName = "Menu";
            connection.Close();

            //Writing menu to the console
            Console.WriteLine($"\n{menu.TableName}\n");

            foreach (DataRow dr in menu.Rows)
            {
                Console.WriteLine("{0}  {1}  {2} ", dr["ItemName"].ToString(), dr["ItemDescrip"].ToString(), dr["ItemPrice"].ToString());
            }

            return;
        }

        public static DataTable GettingInventory(Locations location)
        {
            string connectionString = File.ReadAllText("C:/Users/Owner/Revature/connectionString.txt");
            using SqlConnection connection = new(connectionString);
            string commandText = "SELECT Inventory.ItemID, Inventory.Quantity FROM Inventory WHERE StoreID = @location;";

            connection.Open();
            SqlDataAdapter inventGrabber = new(commandText, connection);
            inventGrabber.SelectCommand.Parameters.AddWithValue("@location", location);
            DataTable inventory = new();
            inventGrabber.Fill(inventory);
            inventory.TableName = "Inventory";

            connection.Close();

            return inventory;
        }
    }
}
