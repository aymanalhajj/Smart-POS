using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockItemModel
    {
        [JsonProperty("dtl_id")]
        public string? Dtl_Id { get; set; }
        [JsonProperty("product_id")]
        public string? ProductId { get; set; }
        [JsonProperty("barcode")]
        public string? ProductBarcode { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("unit_id")]
        public string ProductUnitId { get; set; }
        [JsonProperty("base_price")]
        public float? Price { get; set; }
        [JsonProperty("total_amount")]
        public string? TotalAmount { get; set; }
    }
}
