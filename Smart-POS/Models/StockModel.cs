using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockModel
    {
        public int OrderId { get; set; }

        public object StoreId { get; set; }

        public object OrderDate { get; set; }

        public object? RefId { get; set; }

        public object? AccountId { get; set; }

        public object? CostCtrId { get; set; }

        public int? Accountable { get; set; }

        public object? Notes { get; set; }

        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public int OrderNo { get; set; }

        public object BranchId { get; set; }

        // Present on the new StockinOrderDto/StockoutOrderDto but not yet
        // consumed by StockViewModel - kept so the fields round-trip.
        public int? AccJournalId { get; set; }

        public short DocType { get; set; } = 1;

        public List<StockItemModel>? Items;
    }

}
