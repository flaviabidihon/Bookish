using Bookish.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Models.Orders
{
    public class OrderResponseModel
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<OrderProduct> Products { get; set; }

        public static OrderResponseModel FromOrder(Order order)
        {
            return new OrderResponseModel
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
                User = order.User,
                Products = order.Products
            };
        }
    }
}
