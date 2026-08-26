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
        public int OrderId { get; set; }

        // Not part of the confirmed StockinOrderDto/StockoutOrderDto shape - the
        // list endpoint presumably joins in display names. Field name is a
        // best-effort guess (unconfirmed), see migration report.
        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("costCtrName")]
        public string CostCenterName { get; set; }

        public string OrderDate { get; set; }

        [JsonProperty("refId")]
        public string ReferenceId { get; set; }

        public int Accountable { get; set; }

        public string Notes { get; set; }

        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public float TotalAmount { get; set; }

        public int OrderNo { get; set; }

        public int BranchId { get; set; }
    }
}
