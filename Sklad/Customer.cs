using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> orders { get; set; }

        public Customer()
        {
            orders = new List<Order>();
        }
    }
}
