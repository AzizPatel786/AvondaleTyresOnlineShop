using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvondaleTyresOnlineShop.Data;
using AvondaleTyresOnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace AvondaleTyresOnlineShop.Repository
{
    public class ProductRepository
    {
        private readonly ProductStoreContext _context = null;

        public ProductRepository(ProductStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewProduct(ProductModel model)
        {
            var newProduct = new Products()
            {
                Category = model.Category,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Item = model.Item,
                Quantity = model.Quantity.HasValue ? model.Quantity.Value : 0,
                UpdatedOn = DateTime.UtcNow

            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Id;

        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var products = new List<ProductModel>();
            var allproducts = await _context.Products.ToListAsync();
            if (allproducts?.Any() == true)
            {
                foreach (var product in allproducts)
                {
                    products.Add(new ProductModel()
                    {
                        Category = product.Category,
                        Description = product.Description,
                        Id = product.Id,
                        Item = product.Item,
                        Price = product.Price,
                        Quantity = product.Quantity
                    });
                }
            }
            return products;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                var bookDetails = new ProductModel()
                {
                    Category = product.Category,
                    Description = product.Description,
                    Id = product.Id,
                    Item = product.Item,
                    Price = product.Price,
                    Quantity = product.Quantity
                };

                return bookDetails;
            }

            return null;
        }

        public List<ProductModel> SearchProduct(string title, string authorName)
        {
            return DataSource().Where(x => x.Item.Contains(title) || x.Category.Contains(authorName)).ToList();
        }

        private List<ProductModel> DataSource()
        {
            return new List<ProductModel>()
            {
               new ProductModel(){Id =1, Item="MVC", Category = "Nitish", Description="This is the description for MVC book", Price=1234, Quantity=3 },
                new ProductModel(){Id =2, Item="Dot Net Core", Category = "Nitish", Description="This is the description for MVC book", Price=12345, Quantity=3 },
                new ProductModel(){Id =3, Item="C#", Category = "Monika", Description="This is the description for MVC book", Price=12345, Quantity=3 },
                new ProductModel(){Id =4, Item="Java", Category = "Webgentle", Description="This is the description for MVC book", Price=12345, Quantity=3 },
                new ProductModel(){Id =5, Item="Php", Category = "Webgentle", Description="This is the description for MVC book", Price=12345, Quantity=3 },
 };
        }
    }
}