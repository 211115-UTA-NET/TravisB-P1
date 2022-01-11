using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisB_P1.App;

namespace TravisB_P1.App
{
    public interface IOrder
    {
        void AddToCartAsync(Locations location);
        float Total(List<Product> cart);
    }
}
