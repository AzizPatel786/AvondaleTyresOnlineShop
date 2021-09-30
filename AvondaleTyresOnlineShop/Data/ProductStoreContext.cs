using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
           : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductGallery> ProductGallery { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

    }
}
