using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using se_weather_app.Models;
using System.Net;
using System.Xml.Linq;


namespace se_weather_app.Controllers
{

    
    public class CityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new City();
            return View(model);
        }

        [HttpPost]
        public IActionResult GetCity(City model)
        {
            
            return RedirectToAction(nameof(City), new { city = model.CityName });
        }


        [HttpGet("/city/{city}")]
        public async Task<IActionResult> City(string city)
        {
         
            using var client = new HttpClient();
            
            {

                try
                {

                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=c26a51eff6927b6ac2a511d7799de1b7");
                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    XNode node = JsonConvert.DeserializeXNode(result, "Root");
                    var xml = node.ToString();

                    return Ok(xml);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error: City {httpRequestException.StatusCode}");
                }
            }

        }





        }
}
