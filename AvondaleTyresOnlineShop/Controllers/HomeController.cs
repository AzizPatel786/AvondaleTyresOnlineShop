using AvondaleTyresOnlineShop.Models;
using AvondaleTyresOnlineShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly NewProductAlertConfig _newProductAlertconfiguration;
        private readonly NewProductAlertConfig _thirdPartyProductconfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<NewProductAlertConfig> newProductAlertconfiguration, IMessageRepository messageRepository)
        {
            _logger = logger;
            _newProductAlertconfiguration = newProductAlertconfiguration.Get("InternalProduct");
            _thirdPartyProductconfiguration = newProductAlertconfiguration.Get("ThirdPartyProduct"); _messageRepository = messageRepository;
        }

        public ViewResult Index()
        {
            bool isDisplay = _newProductAlertconfiguration.DisplayNewProductAlert;
            bool isDisplay1 = _thirdPartyProductconfiguration.DisplayNewProductAlert;

           //var value = _messageRepository.GetName();

            //var newProduct = configuration.GetSection("NewProductAlert");
            //var result = newProduct.GetValue<bool>("DisplayNewProductAlert");
            //var productName = newProduct.GetValue<string>("ProductName");

            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
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
