using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupRegionListItemModel
    {
        [JsonProperty("region_id")]
        public object RegionId { get; set; }

        [JsonProperty("region_name_ar")]
        public string RegionNameAr { get; set; }

        [JsonProperty("region_name_en")]
        public string RegionNameEn { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("city_id")]
        public string CityId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}