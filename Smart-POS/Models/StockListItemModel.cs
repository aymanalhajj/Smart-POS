using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class StockListItemModel
    {

        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("store_name")]
        public string StoreName { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("cost_ctr_name")]
        public string CostCenterName { get; set; }

        [JsonProperty("order_date")]
        public string OrderDate { get; set; }

        [JsonProperty("ref_id")]
        public string ReferenceId { get; set; }

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

        [JsonProperty("order_no")]
        public int OrderNo { get; set; }

        [JsonProperty("branch_id")]
        public int BranchId { get; set; }
    }
}
