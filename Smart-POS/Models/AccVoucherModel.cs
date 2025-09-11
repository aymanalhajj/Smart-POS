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
        public int Amount;

        [JsonProperty("account_id")]
        public object AccountId;

        [JsonProperty("ref_id")]
        public object? RefId;

        [JsonProperty("payment_method")]
        public int PaymentMethod;

        [JsonProperty("paid_to")]
        public object? PaidTo;

        [JsonProperty("voucher_date")]
        public object VoucherDate;

        [JsonProperty("posted")]
        public int Posted;

        [JsonProperty("voucher_type")]
        public int VoucherType;

        [JsonProperty("note")]
        public object? Note;

        [JsonProperty("check_no")]
        public int CheckNo;

        [JsonProperty("check_date")]
        public object CheckDate;

        [JsonProperty("cost_cntr_id")]
        public object? CostCntrId;

        [JsonProperty("company_id")]
        public int CompanyId;

        [JsonProperty("total_vat")]
        public double TotalVat;

        [JsonProperty("items")]
        public List<AccVoucherItemModel>? Items;
    }
}
