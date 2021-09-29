using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
