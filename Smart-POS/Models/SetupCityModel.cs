using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupCityModel
    {
        [JsonProperty("city_id")]
        public object CityId { get; set; }

        [JsonProperty("city_name_ar")]
        public string CityNameAr { get; set; }

        [JsonProperty("city_name_en")]
        public string CityNameEn { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}
