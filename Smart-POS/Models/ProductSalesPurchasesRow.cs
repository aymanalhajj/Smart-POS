namespace Smart_POS.Models
{
    public class ProductSalesPurchasesRow
    {
        public string? ProductId { get; set; }
        public string? ProductNo { get; set; }
        public string? ProductName { get; set; }
        public string? Barcode { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SalesQty { get; set; }
        public decimal SalesAmount { get; set; }
        public long TotalCount { get; set; }
    }
}
