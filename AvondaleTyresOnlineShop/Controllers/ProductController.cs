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

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ViewResult> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts();

            return View(data);
        }

        [Route("product-details/{id}", Name = "productDetailsRoute")]
        public async Task<ViewResult> GetProduct(int id)
        {
            var data = await _productRepository.GetProductById(id);

            return View(data);
        }
        public List<ProductModel> SearchProducts(string productName, string categoryName)
        {
            return _productRepository.SearchProduct(productName, categoryName);
        }

        public ViewResult AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel()
            {
                Category = "Brakes"

            };
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _productRepository.AddNewProduct(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, product
                        Id = id });
                }
            }
            ModelState.AddModelError("", "This is my custom error message");
            ModelState.AddModelError("", "This is my second custom error message");

            //ViewBag.IsSuccess = false;
            //ViewBag.ProductId = 0;
            return View();
        }
    }
}
