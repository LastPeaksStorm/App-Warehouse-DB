using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; private set; }

        public Provider()
        {
            Products = new List<Product>();
        }
    }
}
