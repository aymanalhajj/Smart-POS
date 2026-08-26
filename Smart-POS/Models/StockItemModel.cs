using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockItemModel
    {
        // Backend field is "dtlId" - property kept as Dtl_Id since it is
        // referenced throughout the ViewModel/Repository layer under that name.
        [JsonProperty("dtlId")]
        public string? Dtl_Id { get; set; }
        public string? ProductId { get; set; }
        // No "barcode" field exists on the new StockinOrderItemDto/StockoutOrderItemDto -
        // kept unpopulated for backward compatibility, see migration report.
        [JsonProperty("barcode")]
        public string? ProductBarcode { get; set; }
        public int Quantity { get; set; }
        public string ProductUnitId { get; set; }
        public float? Price { get; set; }
        // Backend field is "total", not "totalAmount".
        [JsonProperty("total")]
        public string? TotalAmount { get; set; }
    }
}
