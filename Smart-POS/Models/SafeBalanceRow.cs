namespace Smart_POS.Models
{
    public class SafeBalanceRow
    {
        public string? AccountId { get; set; }
        public string? SafeName { get; set; }
        public string? MainSafeName { get; set; }
        public decimal DebitBal { get; set; }
        public decimal CreditBal { get; set; }
        public decimal Bal { get; set; }
        public string? BalNature { get; set; }
        public long TotalCount { get; set; }
    }
}
