using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupUnitListItemModel
    {
        [JsonProperty("unit_id")]
        public object UnitId { get; set; }

        [JsonProperty("unit_name_ar")]
        public string UnitNameAr { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("unit_name_en")]
        public string UnitNameEn { get; set; }
    }
}