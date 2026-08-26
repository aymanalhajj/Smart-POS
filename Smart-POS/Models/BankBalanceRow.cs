namespace Smart_POS.Models
{
    public class BankBalanceRow
    {
        public string? AccountId { get; set; }
        public string? BankName { get; set; }
        public string? MainBankName { get; set; }
        public decimal DebitBal { get; set; }
        public decimal CreditBal { get; set; }
        public decimal Bal { get; set; }
        public string? BalNature { get; set; }
        public long TotalCount { get; set; }
    }
}
