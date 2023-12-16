using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int PiecesLeft { get; set; }

        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
    }
}
