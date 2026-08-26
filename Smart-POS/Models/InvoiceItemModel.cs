namespace Smart_POS.Models
{
    public class InvoiceItemModel
    {
        public int DtlId { get; set; }
        public int? ProductId { get; set; }
        public string? Barcode { get; set; }
        public string? ProductNameAr { get; set; }
        public string? ProductNameEn { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? PostDiscountTotalPrice { get; set; }
        public decimal? VatPercentage { get; set; }
        public decimal? PreDiscountVatValue { get; set; }
        public decimal? VatValue { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? UnitId { get; set; }

        // Not present on the new InvoiceItemDto. Used only internally by
        // InvoiceItemViewModel.Price's fallback calculation; never sent/received
        // over the wire. Could not migrate — left as a dead property.
        public string? OriginalPrice { get; set; }
    }
}
