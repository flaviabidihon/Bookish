using Bookish.Application.Interfaces;
using Bookish.Application.Models.Products;
using Bookish.DataAccess.Entities;
using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookish.Application.Exceptions;

namespace Bookish.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext databaseContext;

        public ProductService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<ProductResponseModel> GetAllProducts()
        {
            var products = this.databaseContext.Products.ToList();

            var response = products.Select(x => new ProductResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }).ToList();

            return response;
        }

        public ProductResponseModel GetProductById(Guid id)
        {
            var product = this.databaseContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException("This product does not exist. Try entering a valid product ID.");
            }

            return ProductResponseModel.FromProduct(product);
        }

        public ProductResponseModel CreateProduct(CreateProductRequestModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("Name cannot be empty.");
            }

            if (model.Name.Length < 3)
            {
                throw new ValidationException("Name should have length greater than 3.");
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
            };

            this.databaseContext.Products.Add(product);

            this.databaseContext.SaveChanges();

            return ProductResponseModel.FromProduct(product);
        }

        public ProductResponseModel UpdateProduct(Guid id, UpdateProductRequestModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("Name cannot be empty.");
            }

            if (model.Name.Length < 3)
            {
                throw new ValidationException("Name should have length greater than 3.");
            }

            var product = this.databaseContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException("This product does not exist. Try entering a valid product ID.");
            }

            product.Name = model.Name;
            product.Price = model.Price;

            this.databaseContext.SaveChanges();

            return ProductResponseModel.FromProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.databaseContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException("This product does not exist. Try entering a valid product ID.");
            }

            this.databaseContext.Products.Remove(product);

            this.databaseContext.SaveChanges();
        }
    }
}
