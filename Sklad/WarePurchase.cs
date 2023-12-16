using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class WarePurchase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        
    }
}
