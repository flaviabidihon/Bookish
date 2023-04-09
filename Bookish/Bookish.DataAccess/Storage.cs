using Bookish.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Storage
    {
        public static List<Product> Products { get; set; } = new List<Product>();
    }
}
