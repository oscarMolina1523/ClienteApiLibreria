using ConsumirAPILibreria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumirAPILibreria.Controllers
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
            return View();
        }

        public IActionResult OptionsFunctions()
        {
            return View("OptionsFunctions");
        }

        public IActionResult AdministradorCatalogos()
        {
            return View("AdministradorCatalogos");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}