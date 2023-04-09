using Bookish.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Interfaces
{
    public interface IProductService
    {
        List<ProductResponseModel> GetAllProducts();

        ProductResponseModel GetProductById(Guid id);

        ProductResponseModel CreateProduct(CreateProductRequestModel model);

        ProductResponseModel UpdateProduct(Guid id, UpdateProductRequestModel model);

        void DeleteProduct(Guid id);
    }
}
