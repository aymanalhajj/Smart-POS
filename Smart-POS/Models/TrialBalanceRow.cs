namespace Smart_POS.Models
{
    public class TrialBalanceRow
    {
        public string? AccountId { get; set; }
        public string? AccountParent { get; set; }
        public string? AccountName { get; set; }
        public decimal PreDebit { get; set; }
        public decimal PreCredit { get; set; }
        public decimal InDebit { get; set; }
        public decimal InCredit { get; set; }
        public decimal PostDebit { get; set; }
        public decimal PostCredit { get; set; }
        public string? CostCtrName { get; set; }
        public long TotalCount { get; set; }
    }
}
