using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccVoucherItemModel
    {
        [JsonProperty("acc_voucher_dtl_id")]
        public string? AccVoucherDtlId { get; set; }

        [JsonProperty("acc_voucher_id")]
        public string? AccVoucherId { get; set; }

        [JsonProperty("account_id")]
        public string? AccountId { get; set; }

        [JsonProperty("ref_id")]
        public int RefId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("note")]
        public float? Note { get; set; }

        [JsonProperty("cost_cntr_id")]
        public float? CostCntrId { get; set; }

        [JsonProperty("tax_rate")]
        public float? TaxRate { get; set; }

        [JsonProperty("tax_amount")]
        public float? TaxAmount { get; set; }

        [JsonProperty("total_amount")]
        public float? TotalAmount { get; set; }
    }
}
