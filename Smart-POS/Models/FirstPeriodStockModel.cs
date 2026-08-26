using System;
using System.Collections.Generic;

namespace Smart_POS.Models
{
    // Backs setup/first_period_stock. Dedicated model (rather than the shared
    // Invoice family InvoiceModel) because FirstPeriodStockDto has real DateTime?
    // dates and a different field set than PurchaseInvoice/SaleInvoice etc.
    // Property names match the confirmed FirstPeriodStockDto field names, so no
    // [JsonProperty] overrides are needed - Newtonsoft matches case-insensitively.
    public class FirstPeriodStockModel
    {
        public int InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? StoreDate { get; set; }
        public DateTime? ProviderInvDate { get; set; }
        public int? StoreId { get; set; }
        public int? InvoiceType { get; set; }
        public int? SafeId { get; set; }
        public int? CostCtrId { get; set; }
        public int? ProviderId { get; set; }
        public string? ProviderInvId { get; set; }
        public decimal? TotalQuantity { get; set; }
        public decimal? InvoiceTotalAmount { get; set; }
        public string? Notes { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public int? InvoiceNo { get; set; }
        public int? BranchId { get; set; }
        public List<FirstPeriodStockItemModel>? Items { get; set; }
    }
}
