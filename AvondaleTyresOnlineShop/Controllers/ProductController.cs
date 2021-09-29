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

            return View(data);
        }

        [Route("product-details/{id}", Name = "productDetailsRoute")]
        public ViewResult GetProduct(int id)
        {
            var data = _productRepository.GetProductById(id);

            return View(data);
        }
        public List<ProductModel> SearchProducts(string productName, string categoryName)
        {
            return _productRepository.SearchProduct(productName, categoryName);
        }
    }
}
