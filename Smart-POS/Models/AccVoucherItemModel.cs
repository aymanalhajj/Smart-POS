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
        public string? AccVoucherDtlId { get; set; }

        //[JsonProperty("acc_voucher_id")]
        //public string? AccVoucherId { get; set; }

        public string? AccountId { get; set; }

        public string RefId { get; set; }

        public float Amount { get; set; }

        public string? Note { get; set; }

        public string? CostCntrId { get; set; }

        public float? TaxRate { get; set; }

        public float? TaxAmount { get; set; }

        public string? TotalAmount { get; set; }
    }
}
