using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccAccountsListItemModel
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
        public object SubAccount { get; set; }

        [JsonProperty("account_level")]
        public object AccountLevel { get; set; }

        [JsonProperty("acc_date")]
        public object AccDate { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("account_name_en")]
        public object AccountNameEn { get; set; }
    }
    public class TreeAccountsListItemModel
    {
        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("level")]
        public object Level { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("parent_id")]
        public object ParentId { get; set; }
    }
}