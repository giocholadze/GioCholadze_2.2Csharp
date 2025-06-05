using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practice8.Models;

namespace Practice8.Controllers
{
    public class CreateMusicCommand : Controller
    {
        private readonly ILogger<CreateMusicCommand> _logger;

        public CreateMusicCommand(ILogger<CreateMusicCommand> logger)
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
