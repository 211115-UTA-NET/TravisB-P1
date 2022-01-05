

namespace TravisB_P1
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
