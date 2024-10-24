using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockModel
    {
        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("store_id")]
        public object StoreId { get; set; }

        [JsonProperty("order_date")]
        public object OrderDate { get; set; }

        [JsonProperty("ref_id")]
        public object? RefId { get; set; }

        [JsonProperty("account_id")]
        public object? AccountId { get; set; }

        [JsonProperty("cost_ctr_id")]
        public object? CostCtrId { get; set; }

        [JsonProperty("accountable")]
        public int Accountable { get; set; }

        [JsonProperty("notes")]
        public object? Notes { get; set; }

        [JsonProperty("company_id")]
        public int CompanyId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("total_amount")]
        public double TotalAmount { get; set; }

        [JsonProperty("order_no")]
        public int OrderNo { get; set; }

        [JsonProperty("branch_id")]
        public object BranchId { get; set; }

        [JsonProperty("items")]
        public List<StockItemModel>? Items;
    }

}
