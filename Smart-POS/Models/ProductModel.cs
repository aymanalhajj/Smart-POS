using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class ProductModel
    {
        [JsonProperty("product_id")]
        public object ProductId { get; set; }

        [JsonProperty("product_name_ar")]
        public string ProductNameAr { get; set; }

        [JsonProperty("product_name_en")]
        public string ProductNameEn { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("type_id")]
        public string TypeId { get; set; }

        [JsonProperty("tax_group_id")]
        public string TaxGroupId { get; set; }

        [JsonProperty("tax_value")]
        public string TaxValue { get; set; }

        [JsonProperty("default_unit_id")]
        public string DefaultUnitId { get; set; }

        [JsonProperty("product_group_id")]
        public object ProductGroupId { get; set; }

        [JsonProperty("purchase_price")]
        public object PurchasePrice { get; set; }

        [JsonProperty("sell_price")]
        public object SellPrice { get; set; }

        [JsonProperty("provider_id")]
        public string ProviderId { get; set; }

        [JsonProperty("product_status")]
        public string ProductStatus { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }

        [JsonProperty("product_no")]
        public string ProductNo { get; set; }
    }
}
