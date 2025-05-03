using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupCountryModel
    {
        [JsonProperty("country_id")]
        public object CountryId { get; set; }

        [JsonProperty("name_ar")]
        public string NameAr { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("nationality_name_ar")]
        public string NationalityNameAr { get; set; }

        [JsonProperty("nationality_name_en")]
        public string NationalityNameEn { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}
