namespace Smart_POS.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int? InvoiceNo { get; set; }
        public int? InvoiceType { get; set; }
        public int? ProviderId { get; set; }
        public string? ProviderInvId { get; set; }
        public string? ProviderInvDate { get; set; }
        public int? ClientId { get; set; }
        public string? ProviderNameAr { get; set; }
        public string? ProviderNameEn { get; set; }
        public string? ClientNameAr { get; set; }
        public string? ClientNameEn { get; set; }
        public string? StoreNameAr { get; set; }
        public string? StoreNameEn { get; set; }
        public string? BranchNameAr { get; set; }
        public string? BranchNameEn { get; set; }
        public string? CostCtrNameAr { get; set; }
        public string? CostCtrNameEn { get; set; }
        public string? BankNameAr { get; set; }
        public string? BankNameEn { get; set; }
        public string? SafeNameAr { get; set; }
        public string? SafeNameEn { get; set; }
        public string? InvoiceDate { get; set; }
        public string? StoreDate { get; set; }
        public decimal? PreTaxTotalAmount { get; set; }
        public decimal? ClientDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? PostDiscountTotalAmount { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? InvoiceTotalAmount { get; set; }
        public int? PaymentType { get; set; }
        public int? PaymentMethod { get; set; }
        public decimal? PaidCashAmount { get; set; }
        public decimal? PaidBankAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? DeferredAmount { get; set; }
        public int? BankAccId { get; set; }
        public int? SafeId { get; set; }
        public decimal? TotalQuantity { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? StoreId { get; set; }
        public int? CostCtrId { get; set; }
        public string? Notes { get; set; }
        public List<InvoiceItemModel> Items { get; set; } = new();

        // Not present on the new InvoiceDto (no header-level equivalent — the closest
        // thing, PreDiscountVatValue, lives per line-item on InvoiceItemDto). Kept here
        // only so it keeps flowing through InvoiceViewModel's local ClientDiscount-%
        // calculation (summed client-side from item PreDiscountVatValue in CalcSummary);
        // it is not populated from GET responses and is extra/ignored JSON on POST.
        public decimal? PreDiscountTotalVat { get; set; }
    }
}
