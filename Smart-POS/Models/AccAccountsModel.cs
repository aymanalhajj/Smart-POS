using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccAccountsModel
    {
        [JsonProperty("account_id")]
        public object AccountId { get; set; }

        [JsonProperty("account_name_ar")]
        public string AccountNameAr { get; set; }

        [JsonProperty("account_nature")]
        public object AccountNature { get; set; }

        [JsonProperty("account_type")]
        public object AccountType { get; set; }

        [JsonProperty("account_parent")]
        public object AccountParent { get; set; }

        [JsonProperty("sub_account")]
        public string SubAccount { get; set; }

        [JsonProperty("account_level")]
        public object AccountLevel { get; set; }

        [JsonProperty("acc_date")]
        public object AccDate { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("account_name_en")]
        public string AccountNameEn { get; set; }
    }
}