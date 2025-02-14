using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly string[] _cities;
		private readonly string[] _hobbies;

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _cities = ["Myrtle Beach", "Denver", "Reykjavík", "Toronto", "Miami"];
            _hobbies = ["Coding", "Bowling", "Golf", "Chess", "Basketball"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cities()
        {
            ViewBag.Cities = _cities;
			return View();
		}

        public IActionResult Hobbies()
        {
            ViewBag.Hobbies = _hobbies;
			return View();
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
