using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockModel
    {
        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("store_id")]
        public int StoreId { get; set; }

        [JsonProperty("order_date")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("ref_id")]
        public string RefId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("cost_ctr_id")]
        public int CostCtrId { get; set; }

        [JsonProperty("accountable")]
        public int Accountable { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("company_id")]
        public int CompanyId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("total_amount")]
        public int TotalAmount { get; set; }

        [JsonProperty("acc_journal_id")]
        public int AccJournalId { get; set; }

        [JsonProperty("order_no")]
        public int OrderNo { get; set; }

        [JsonProperty("branch_id")]
        public int BranchId { get; set; }

        [JsonProperty("items")]
        public List<StockItemModel>? Items;
    }

}
