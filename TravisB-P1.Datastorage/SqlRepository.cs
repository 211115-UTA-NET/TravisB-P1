using System.Data.SqlClient;
using TravisB_P1.Logic;

namespace TravisB_P1.DataStorage
{
    public class SqlRepository : IRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        public SqlRepository(string connectionString, ILogger<SqlRepository> logger)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _logger = logger;
        }

        public async Task<IEnumerable<Inventory>> GetStoreInventoryAsync(Locations storeChoice)
        {
            List<Inventory> inventory = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand cmd = new(
                @"SELECT ItemName, ItemDescrip, ItemPrice, Quantity
                FROM Inventory
                    INNER JOIN Items ON Inventory.ItemID = Items.ItemID
                    INNER JOIN Locations ON Locations.StoreID = Inventory.StoreID
                    WHERE Locations.City = @locationChosen",
            connection);

            cmd.Parameters.AddWithValue("@locationChosen", storeChoice);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (await reader.ReadAsync())
            {
                var item = (Items)Enum.Parse(typeof(Items), reader.GetString(0));
                string itemDescription = reader.GetString(1);
                string itemPrice = $"${reader.GetString(2)}";
                int totalAvailable = reader.GetInt32(3);
                inventory.Add(new(item, itemDescription, itemPrice, totalAvailable));
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed select statement for inventory of store {store}", storeChoice);

            return inventory;
        }

        public void AddNewOrder(Order order, Customer customer)
        {
            using SqlConnection connection = new(_connectionString);
            connection.OpenAsync();

            string cmdText = @"INSERT INTO Orders (CustomerName, LocationID, ItemID, QuantityOrdered)
                             VALUES (@CustomerName, @LocationID, @ItemID, @QuantityOrdered)";

            using SqlCommand cmd = new(cmdText, connection);

            cmd.Parameters.AddWithValue("@CustomerName", customer.name);
            cmd.Parameters.AddWithValue("@LocationID", order.location.ToString());

            foreach (Product item in order.shoppingCart)
            {
                cmd.Parameters.AddWithValue("@ItemID", item.productName);
                cmd.Parameters.AddWithValue("@QuantityOrdered", item.quantity);
            }
        }
    }
}
