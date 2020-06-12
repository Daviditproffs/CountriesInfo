using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CountriesInfo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CountriesInfo.Controllers
{
    public class CountryController : Controller
    {
      

        // GET: Country/Details/{countrycode}
        public async Task<IActionResult> Details(string countryId)
        {
            Country country;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://restcountries.eu/rest/v2/alpha/" + countryId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    country = JsonConvert.DeserializeObject<Country>(apiResponse);

                }
            }

            return View(country);
        }

    }
}