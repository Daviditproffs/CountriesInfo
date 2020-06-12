using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesInfo.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("callingcodes")]
        public string[] CallingCode { get; set; }
              
        [JsonProperty("altSpellings")]
        public string[] AltSpellings { get; set; }
        
        [JsonProperty("region")]
        public string Region { get; set; }
        
        [JsonProperty("population")]
        public int Population { get; set; }
        
        [JsonProperty("demonym")]
        public string Demonym { get; set; }
        
        [JsonProperty("nativeName")]
        public string NativeName { get; set; }
        
        [JsonProperty("currencies")]
        public List<Currency> Currencies { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }
        
        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("alpha3Code")]
        public string Alpha3Code { get; set; }

    }
}
