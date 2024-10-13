using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockItemModel
    {
        [JsonProperty("dtl_id")]
        public int DtlId { get; set; }

        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("unit_id")]
        public int UnitId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("base_price")]
        public int BasePrice { get; set; }

        [JsonProperty("total_amount")]
        public int TotalAmount { get; set; }
    }
}
