using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class ProviderModel
    {
        [JsonProperty("provider_id")]
        public object ProviderId { get; set; }

        [JsonProperty("name_ar")]
        public string NameAr { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("mobile_no")]
        public string MobileNo { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("tel_no")]
        public string TelNo { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("tax_no")]
        public string TaxNo { get; set; }

        [JsonProperty("country_id")]
        public object CountryId { get; set; }

        [JsonProperty("city_id")]
        public object CityId { get; set; }

        [JsonProperty("region_id")]
        public object RegionId { get; set; }

        [JsonProperty("building_no")]
        public string BuildingNo { get; set; }

        [JsonProperty("sreet")]
        public string Sreet { get; set; }

        [JsonProperty("post_code")]
        public string PostCode { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("account_id")]
        public object AccountId { get; set; }
    }
}
