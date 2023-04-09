using Bookish.Application.Interfaces;
using Bookish.Application.Models.Products;
using Bookish.DataAccess.Entities;
using Bookish.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Bookish.Application.Exceptions;

namespace Bookish.Api.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.productService.GetAllProducts());
        }

        [HttpGet("{id}")] 
        public IActionResult GetProductById(Guid id)
        {
            try
            {
                return Ok(this.productService.GetProductById(id));
            }
            catch(NotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequestModel requestModel)
        {
            try
            {
                return Ok(this.productService.CreateProduct(requestModel));
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, UpdateProductRequestModel requestModel)
        {
            try
            {
                return Ok(this.productService.UpdateProduct(id, requestModel));
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
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {
                this.productService.DeleteProduct(id);
                return NoContent();
            }
            catch (NotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
    
}
