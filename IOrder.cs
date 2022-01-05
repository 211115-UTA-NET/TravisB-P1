using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TravisB_P1
{
    public interface IOrder
    {
        bool AddToCart();
        void FinalizeOrder(Order order, Customer customer);
        void AddToHistory(Order order);
    }
}
