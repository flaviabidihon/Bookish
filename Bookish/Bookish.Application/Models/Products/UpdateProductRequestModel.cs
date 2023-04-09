using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.Application.Models.Products
{
    public class UpdateProductRequestModel
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
