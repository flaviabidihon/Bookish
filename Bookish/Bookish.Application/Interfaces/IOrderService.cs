using Bookish.Application.Models.Orders;
using Bookish.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Interfaces
{
    public interface IOrderService
    {
        List<Models.Orders.OrderResponseModel> GetAllOrders();

        Models.Orders.OrderResponseModel GetOrderById(Guid id);

        Models.Orders.OrderResponseModel CreateOrder(CreateOrderRequestModel model);

        Models.Orders.OrderResponseModel UpdateOrder(Guid id, UpdateOrderRequestModel model);

        void DeleteOrder(Guid id);
    }
}
