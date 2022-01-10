using TravisB_P1.Logic;

namespace TravisB_P1.DataStorage
{
    public interface IRepository
    {
        Task<IEnumerable<Inventory>> GetStoreInventoryAsync(Locations location);
        void AddNewOrder(Order thisOrder, Customer thisCustomer);
    }
}
