using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupBranchModel
    {
        [JsonProperty("branch_id")]
        public object BranchId { get; set; }

        [JsonProperty("name_ar")]
        public string NameAr { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("tel_no")]
        public string TelNo { get; set; }

        [JsonProperty("mobile_no")]
        public object MobileNo { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("comercial_rec_no")]
        public string ComercialRecNo { get; set; }

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

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}
