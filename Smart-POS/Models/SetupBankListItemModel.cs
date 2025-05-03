using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupBankListItemModel
    {
        [JsonProperty("bank_acc_id")]
        public object BankAccId { get; set; }

        [JsonProperty("acc_name_ar")]
        public string AccNameAr { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("tel_no")]
        public string TelNo { get; set; }

        [JsonProperty("mobile_no")]
        public object MobileNo { get; set; }

        [JsonProperty("country_id")]
        public object CountryId { get; set; }

        [JsonProperty("city_id")]
        public object CityId { get; set; }

        [JsonProperty("region_id")]
        public object RegionId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("for_all_branches")]
        public string ForAllBranches { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("acc_name_en")]
        public string AccNameEn { get; set; }
    }
}
