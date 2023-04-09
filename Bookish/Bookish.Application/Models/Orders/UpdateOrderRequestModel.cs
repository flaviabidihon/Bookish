using Bookish.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Models.Orders
{
    public class UpdateOrderRequestModel
    {
        public User User { get; set; }
        public List<OrderProduct> Products { get; set; }
    }
}
