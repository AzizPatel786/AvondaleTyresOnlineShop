using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvondaleTyresOnlineShop.Data;
using AvondaleTyresOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using AvondaleTyresOnlineShop.Enums;

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
                CategoryId = model.CategoryId,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Item = model.Item,
                Quantity = model.Quantity.HasValue ? model.Quantity.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,

            };
            newProduct.productGallery = new List<ProductGallery>();

            foreach (var file in model.Gallery)
            {
                newProduct.productGallery.Add(new ProductGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Id;

        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _context.Products
                  .Select(product => new ProductModel()
                  {
                      CategoryId = product.CategoryId,
                        Category = product.Category.Name,
                        Description = product.Description,
                        Id = product.Id,
                        Item = product.Item,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CoverImageUrl = product.CoverImageUrl
                  }).ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.Products.Where(x => x.Id == id)
                 .Select(product => new ProductModel()
                 {
                     CategoryId = product.CategoryId,
                    Category = product.Category.Name,
                    Description = product.Description,
                    Id = product.Id,
                    Item = product.Item,
                    Price = product.Price,
                    Quantity = product.Quantity,
                     CoverImageUrl = product.CoverImageUrl,

                     Gallery = product.productGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Name = g.Name,
                         URL = g.URL
                     }).ToList()
                 }).FirstOrDefaultAsync();
        }

        public List<ProductModel> SearchBook(string item, string categoryName)
        {
            return null;
        }
    }
}