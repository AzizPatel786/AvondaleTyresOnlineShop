using AvondaleTyresOnlineShop.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Components
{
    
        public class TopProductsViewComponent : ViewComponent
        {
        private readonly ProductRepository _bookRepository;

        public TopProductsViewComponent(ProductRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var products = await _bookRepository.GetTopProductsAsync(count);
            return View(products);
        }
        }
    
}
