using Bookish.Application.Exceptions;
using Bookish.Application.Interfaces;
using Bookish.Application.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Bookish.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(this.orderService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            try
            {
                return Ok(this.orderService.GetOrderById(id));
            }
            catch (NotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderRequestModel requestModel)
        {
            try
            {
                return Ok(this.orderService.CreateOrder(requestModel));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Guid id, UpdateOrderRequestModel requestModel)
        {
            try
            {
                return Ok(this.orderService.UpdateOrder(id, requestModel));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (NotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                this.orderService.DeleteOrder(id);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
