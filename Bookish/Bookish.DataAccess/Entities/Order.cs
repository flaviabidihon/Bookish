using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public List<OrderProduct> Products { get; set; }
    }
}
