using TravisB_P1API.Logic;

namespace TravisB_P1API.DataStorage
{
    public interface IRepository
    {
        Task<IEnumerable<Inventory>> GetStoreInventoryAsync(Locations location);
        void AddNewOrder(Order thisOrder, Customer thisCustomer);
    }
}