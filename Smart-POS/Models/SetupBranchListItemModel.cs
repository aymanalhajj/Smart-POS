using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupBranchListItemModel
    {
        [JsonPropertyName("branch_id")]
        public object BranchId { get; set; }

        [JsonPropertyName("name_ar")]
        public string NameAr { get; set; }

        [JsonPropertyName("name_en")]
        public string NameEn { get; set; }

        [JsonPropertyName("tel_no")]
        public string TelNo { get; set; }

        [JsonPropertyName("mobile_no")]
        public object MobileNo { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("comercial_rec_no")]
        public string ComercialRecNo { get; set; }

        [JsonPropertyName("tax_no")]
        public string TaxNo { get; set; }

        [JsonPropertyName("country_id")]
        public object CountryId { get; set; }

        [JsonPropertyName("city_id")]
        public object CityId { get; set; }

        [JsonPropertyName("region_id")]
        public object RegionId { get; set; }

        [JsonPropertyName("building_no")]
        public string BuildingNo { get; set; }

        [JsonPropertyName("sreet")]
        public string Sreet { get; set; }

        [JsonPropertyName("post_code")]
        public string PostCode { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("company_id")]
        public object CompanyId { get; set; }
    }
}
