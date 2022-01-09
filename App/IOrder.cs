using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisB_P1.App;
using TravisB_P1.Console.Dtos;

namespace TravisB_P1.App
{
    public interface IOrder
    {
        bool AddToCart();
        float Total(List<Product> cart);
    }
}
