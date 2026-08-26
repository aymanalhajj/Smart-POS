namespace Smart_POS.Models
{
    public class InvoiceListItemModel
    {
        public int InvoiceId { get; set; }
        public string? InvoiceDate { get; set; }
        public string? StoreDate { get; set; }
        public int? StoreId { get; set; }
        public string? InvoiceType { get; set; }
        public string? PaymentType { get; set; }
        public int? PaymentTypeCode { get; set; }
        public int? SafeId { get; set; }
        public int? CostCtrId { get; set; }
        public string? ClientNameAr { get; set; }
        public string? ClientNameEn { get; set; }
        public string? ProviderNameAr { get; set; }
        public string? ProviderNameEn { get; set; }
        public decimal? PreTaxTotalAmount { get; set; }
        public decimal? ClientDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? PostDiscountTotalAmount { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? InvoiceTotalAmount { get; set; }
        public decimal? PaidCashAmount { get; set; }
        public decimal? PaidBankAmount { get; set; }
        public string? Notes { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public int? BankAccId { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? DeferredAmount { get; set; }
        public int? AccJournalId { get; set; }
        public int? InvoiceNo { get; set; }
        public int? BranchId { get; set; }
        public string? BankNameAr { get; set; }
        public string? BankNameEn { get; set; }
        public string? SafeNameAr { get; set; }
        public string? SafeNameEn { get; set; }
    }
}
