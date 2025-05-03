using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupCurrencyModel
    {
        [JsonProperty("currency_id")]
        public object CurrencyId { get; set; }

        [JsonProperty("code_ar")]
        public string CodeAr { get; set; }

        [JsonProperty("name_ar")]
        public string NameAr { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public object CreatedAt { get; set; }

        [JsonProperty("modified_by")]
        public object ModifiedBy { get; set; }

        [JsonProperty("modified_at")]
        public object ModifiedAt { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("name_en")]
        public string NameEn { get; set; }

        [JsonProperty("code_en")]
        public string CodeEn { get; set; }
    }
}
