namespace Smart_POS.Models
{
    public class InvoiceTotalByClientRow
    {
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceType { get; set; }
        public string? ClientName { get; set; }
        public decimal PurchaseTotal { get; set; }
        public decimal SalesTotal { get; set; }
        public long TotalCount { get; set; }
    }
}
