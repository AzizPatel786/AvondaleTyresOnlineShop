using AvondaleTyresOnlineShop.Models;
using AvondaleTyresOnlineShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvondaleTyresOnlineShop.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AvondaleTyresOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository = null;
        private readonly CategoryRepository _categoryRepository = null;

        public ProductController(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
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
        public List<ProductModel> SearchBooks(string productName, string categoryName)
        {
            return _productRepository.SearchBook(productName, categoryName);
        }

        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, int bookId = 0)
        {
            var model = new ProductModel();

            ViewBag.Language = new SelectList(await _categoryRepository.GetCategories(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
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
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
                }
            }

            ViewBag.Language = new SelectList(await _categoryRepository.GetCategories(), "Id", "Name");


            return View();
        }
    }
}
