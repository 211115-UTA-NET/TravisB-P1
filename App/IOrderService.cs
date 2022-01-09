using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisB_P1.App.Dtos;

namespace TravisB_P1.App
{
    public interface IOrderService
    {
        Task<List<Inventory>> GetInventoryAsync(Locations location);
        void FinalizeOrderAsync(Order order, Customer customer);
    }
}
