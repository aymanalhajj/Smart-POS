using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupTaxGroupListItemModel
    {
        [JsonProperty("group_id")]
        public object GroupId { get; set; }

        [JsonProperty("name_ar")]
        public string NameAr { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("group_value")]
        public string GroupValue { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}