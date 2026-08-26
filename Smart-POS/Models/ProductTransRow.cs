namespace Smart_POS.Models
{
    public class ProductTransRow
    {
        public long Seq { get; set; }
        public string? ProductNo { get; set; }
        public string? ProductBarcode { get; set; }
        public string? ProductName { get; set; }
        public string? MainProductName { get; set; }
        public decimal Bal { get; set; }
        public decimal CostAvg { get; set; }
        public decimal CostTotal { get; set; }
        public decimal FirstPeriod { get; set; }
        public decimal Purchase { get; set; }
        public decimal PurReturn { get; set; }
        public decimal Sales { get; set; }
        public decimal SalesReturn { get; set; }
        public decimal Stockin { get; set; }
        public decimal Stockout { get; set; }
        public decimal Adjustment { get; set; }
        public long TotalCount { get; set; }
    }
}
