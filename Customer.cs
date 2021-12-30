using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TravisB_P0
{
    public class Customer
    {
        private string _Name;
        public Customer(string Name)
        {
            this._Name = Name;
        }

        public string Name { get { return _Name; } }
    }
}
