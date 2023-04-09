using Bookish.Application.Exceptions;
using Bookish.Application.Interfaces;
using Bookish.Application.Models.Orders;
using Bookish.DataAccess.Entities;
using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext databaseContext;

        public OrderService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<OrderResponseModel> GetAllOrders()
        {
            var orders = this.databaseContext.Orders.ToList();

            var response = orders.Select(x => new OrderResponseModel
            {
                Id = x.Id,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
                User = x.User,
                Products = x.Products,
            }).ToList();

            return response;
        }

        public OrderResponseModel GetOrderById(Guid id)
        {
            var order = this.databaseContext.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new NotFoundException("This order does not exist. Try entering a valid order ID.");
            }

            return OrderResponseModel.FromOrder(order);
        }

        public OrderResponseModel CreateOrder(CreateOrderRequestModel model)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                User = model.User,
                Products = model.Products,
            };

            this.databaseContext.Orders.Add(order);

            this.databaseContext.SaveChanges();

            return OrderResponseModel.FromOrder(order);
        }

        public OrderResponseModel UpdateOrder(Guid id, UpdateOrderRequestModel model)
        {
            var order = this.databaseContext.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new NotFoundException("This order does not exist. Try entering a valid order ID.");
            }

            order.User = model.User;
            order.Products = model.Products;

            this.databaseContext.SaveChanges();

            return OrderResponseModel.FromOrder(order);
        }

        public void DeleteOrder(Guid id)
        {
            var order = this.databaseContext.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new NotFoundException("This order does not exist. Try entering a valid order ID.");
            }

            this.databaseContext.Orders.Remove(order);

            this.databaseContext.SaveChanges();
        }
    }
}
