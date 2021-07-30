using Blog.Web2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Blog.Web2.Models.IndexViewModel;

namespace Blog.Web2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();


            return View(model);
        }
        public IActionResult CreateRaven()
        {
            var model = new IndexViewModel();


            return View(model);
        }
        public IActionResult Privacy()
        {
            var modelRaven = new ravendb();
            return View(modelRaven);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
