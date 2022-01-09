using TravisB_P1.API.Dtos;

namespace TravisB_P1.API
{
    public interface IRepository
    {
        Task<IEnumerable<InventoryDtos>> GetStoreInventoryAsync(Locations location);
        void AddNewOrder(Order thisOrder, CustomerDtos thisCustomer);
    }
}