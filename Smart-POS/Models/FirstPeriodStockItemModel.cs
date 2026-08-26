namespace Smart_POS.Models
{
    // Line item for FirstPeriodStockModel - matches FirstPeriodStockItemDto exactly
    // by name, no [JsonProperty] overrides needed.
    public class FirstPeriodStockItemModel
    {
        public int DtlId { get; set; }
        public int? InvoiceId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductUnitId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
