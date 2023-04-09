using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess.Entities
{
    public class OrderProduct
    {
        [Key]
        public Guid OrderId { get; set; }
        [Required]
        public Order Order { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
