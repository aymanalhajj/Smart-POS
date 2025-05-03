using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccVoucherModel
    {

        [JsonProperty("acc_voucher_id")]
        public int AccVoucherId;

        [JsonProperty("amount")]
        public object Amount;

        [JsonProperty("account_id")]
        public int AccountId;

        [JsonProperty("ref_id")]
        public int RefId;

        [JsonProperty("payment_method")]
        public object? PaymentMethod;

        [JsonProperty("paid_to")]
        public object? PaidTo;

        [JsonProperty("VoucherDate")]
        public object? VoucherDate;

        [JsonProperty("posted")]
        public object? Posted;

        [JsonProperty("voucher_type")]
        public object? VoucherType;

        [JsonProperty("note")]
        public object? Note;

        [JsonProperty("check_no")]
        public object? CheckNo;

        [JsonProperty("check_date")]
        public object? CheckDate;

        [JsonProperty("cost_cntr_id")]
        public object? CostCntrId;

        [JsonProperty("company_id")]
        public object? CompanyId;

        [JsonProperty("total_vat")]
        public object? TotalVat;

        [JsonProperty("items")]
        public List<AccVoucherItemModel>? Items;
    }
}
