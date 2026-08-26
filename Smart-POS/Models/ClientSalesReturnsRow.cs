namespace Smart_POS.Models
{
    public class ClientSalesReturnsRow
    {
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public string? TransType { get; set; }
        public string? ClientName { get; set; }
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SalesTotal { get; set; }
        public long TotalCount { get; set; }
    }
}
