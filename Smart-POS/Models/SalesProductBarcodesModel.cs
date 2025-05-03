using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductBarcodesModel
    {
        [JsonProperty("product_barcode_id")]
        public object ProductBarcodeId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("barcode")]
        public object Barcode { get; set; }

        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
    }
}