namespace Smart_POS.Models
{
    public class StoresStatisticsRow
    {
        public long Seq { get; set; }
        public string? ProductNo { get; set; }
        public string? ProductBarcode { get; set; }
        public string? ProductName { get; set; }
        public string? StoreName { get; set; }
        public decimal Bal { get; set; }
        public decimal CostAvg { get; set; }
        public decimal CostTotal { get; set; }
        public long TotalCount { get; set; }
    }
}
