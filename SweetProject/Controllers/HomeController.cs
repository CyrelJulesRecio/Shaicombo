using Microsoft.AspNetCore.Mvc;
using SweetProject.Models;
using System.Diagnostics;

namespace SweetProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SavePlan([FromBody] PlanInput input)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserPlan.txt");
            var content = $"Date Type: {input.DateType}\nDate: {input.Date}\nPlace: {input.Place}\nNote: {input.Note}\n---\n";

            System.IO.File.AppendAllText(filePath, content);

            return Ok();
        }

        public class PlanInput
        {
            public string DateType { get; set; }
            public string Date { get; set; }
            public string Place { get; set; }
            public string Note { get; set; }
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