namespace Smart_POS.Models
{
    public class IncomeStatementRow
    {
        public string? AccountId { get; set; }
        public string? AccountParent { get; set; }
        public string? AccountName { get; set; }
        public decimal DebitBal { get; set; }
        public decimal CreditBal { get; set; }
        public string? CostCtrName { get; set; }
        public long TotalCount { get; set; }
    }
}
