using AvondaleTyresOnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            configuration = _configuration;
        }

        public ViewResult Index()
        {
            var result = configuration["AppName"];
            var key1 = configuration["infoObj:key1"];
            var key2 = configuration["infoObj:key2"];
            var key3 = configuration["infoObj:key3:key3obj1"];
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
