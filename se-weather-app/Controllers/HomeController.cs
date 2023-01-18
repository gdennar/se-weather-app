using Microsoft.AspNetCore.Mvc;
using se_weather_app.Models;
using System.Diagnostics;

namespace se_weather_app.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



      


        [HttpPost]
        public ActionResult SendCity(City model)
        {
            if (ModelState.IsValid)
            {

            }
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