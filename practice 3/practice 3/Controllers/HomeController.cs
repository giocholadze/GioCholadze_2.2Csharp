using Microsoft.AspNetCore.Mvc;
using practice_3.Models;
using System.Diagnostics;

namespace practice_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionstring = "Data Source=DESKTOP-BS2HUTQ\\SQLEXPRESS;Initial Catalog=orders;Integrated Security=True;Trust Server Certificate=TrueData Source=DESKTOP-BS2HUTQ\\SQLEXPRESS;Initial Catalog=orders;Integrated Security=True;Trust Server Certificate=True";
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
