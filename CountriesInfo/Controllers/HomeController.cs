using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CountriesInfo.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;

namespace CountriesInfo.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Country> countryList = new List<Country>();
            if (HttpContext.Session.GetString("Countries") == null)
            {

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://restcountries.eu/rest/v2/all"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        countryList = JsonConvert.DeserializeObject<List<Country>>(apiResponse);
                        HttpContext.Session.SetString("Countries", JsonConvert.SerializeObject(countryList));
                    }
                }
                return View(countryList);
            }
            else
            {
                var sessionValue = HttpContext.Session.GetString("Countries");
                return View(JsonConvert.DeserializeObject<List<Country>>(sessionValue));
            }

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
