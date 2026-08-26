namespace Smart_POS.Models
{
    public class PurchasesPeriodRow
    {
        public string? ProductId { get; set; }
        public string? ProductNo { get; set; }
        public string? ProductName { get; set; }
        public string? Barcode { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal PurchaseAmount { get; set; }
        public long TotalCount { get; set; }
    }
}
