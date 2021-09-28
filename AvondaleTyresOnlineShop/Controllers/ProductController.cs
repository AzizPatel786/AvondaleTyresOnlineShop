using AvondaleTyresOnlineShop.Models;
using AvondaleTyresOnlineShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public ViewResult GetAllProducts()
        {
            var data = _productRepository.GetAllProducts();

            return View();
        }

        public ProductModel GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public List<ProductModel> SearchProducts(string productName, string categoryName)
        {
            return _productRepository.SearchProduct(productName, categoryName);
        }
    }
}
