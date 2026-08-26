using System;

namespace Smart_POS.Models
{
    // Best-effort list-row shape for setup/first_period_stocks - no separate list DTO
    // is documented, so this mirrors the header FirstPeriodStockDto fields (minus
    // Items), matching the pattern used by the other list endpoints in this app.
    // Only InvoiceNo/InvoiceDate/InvoiceTotalAmount/InvoiceType/ProviderId are
    // currently bound by FirstPeriodStockPage.xaml's search results ListView.
    public class FirstPeriodStockListItemModel
    {
        public int InvoiceId { get; set; }
        public int? InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceTotalAmount { get; set; }
        public int? InvoiceType { get; set; }
        public int? ProviderId { get; set; }
        public int? StoreId { get; set; }
        public int? BranchId { get; set; }
    }
}
