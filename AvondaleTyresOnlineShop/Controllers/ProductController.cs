using AvondaleTyresOnlineShop.Models;
using AvondaleTyresOnlineShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvondaleTyresOnlineShop.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AvondaleTyresOnlineShop.Data;
using Microsoft.AspNetCore.Http;

namespace AvondaleTyresOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository = null;
        private readonly ICategoryRepository _categoryRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("all-products")]
        public async Task<ViewResult> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts();

            return View(data);
        }

        [Route("product-details/{id:int:min(1)}", Name = "productDetailsRoute")]
        public async Task<ViewResult> GetProduct(int id)
        {
            var data = await _productRepository.GetProductById(id);

            return View(data);
        }
        public List<ProductModel> SearchProducts(string productName, string categoryName)
        {
            return _productRepository.SearchProduct(productName, categoryName);
        }

        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, int productId = 0)
        {
            var model = new ProductModel();


            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (productModel.CoverPhoto != null)
                {
                    string folder = "products/cover/";
                    productModel.CoverImageUrl = await UploadImage(folder, productModel.CoverPhoto);
                }

                if (productModel.GalleryFiles != null)
                {
                    string folder = "products/gallery/";

                    productModel.Gallery = new List<GalleryModel>();

                    foreach (var file in productModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        productModel.Gallery.Add(gallery);
                    }
                }

                if (productModel.PricechartPdf != null)
                {
                    string folder = "products/pdf/";
                    productModel.PricechartPdfUrl = await UploadImage(folder, productModel.PricechartPdf);
                }

              

                int id = await _productRepository.AddNewProduct(productModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
