using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class StoreTransferItemModel
    {
        [JsonProperty("dtl_id")]
        public string? Dtl_Id { get; set; }

        [JsonProperty("transfer_id")]
        public string? TransferId { get; set; }

        [JsonProperty("product_id")]
        public string? ProductId { get; set; }

        [JsonProperty("product_unit_id")]
        public int ProductUnitId { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("price")]
        public float? Price { get; set; }
    }
}
