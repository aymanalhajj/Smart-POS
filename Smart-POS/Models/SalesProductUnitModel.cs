using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductUnitModel
    {
        [JsonProperty("product_unit_id")]
        public object ProductUnitId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("unit_id")]
        public string UnitId { get; set; }

        [JsonProperty("unit_value")]
        public string UnitValue { get; set; }

        [JsonProperty("purchase_price")]
        public object PurchasePrice { get; set; }

        [JsonProperty("sell_price")]
        public object SellPrice { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}