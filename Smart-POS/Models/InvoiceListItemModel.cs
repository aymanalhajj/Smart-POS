using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class InvoiceListItemModel
    {
        [JsonProperty("order_date")]
        public object? OrderDate { get; set; }

        [JsonProperty("invoice_id")]
        public object InvoiceId { get; set; }

        [JsonProperty("order_id")]
        public object OrderId { get; set; }

        [JsonProperty("order_no")]
        public int OrderNo { get; set; }

        [JsonProperty("invoice_no")]
        public object InvoiceNo { get;set; }
        [JsonProperty("provider_inv_id")]
        public object? ProviderInvId { get; set; }
        [JsonProperty("notes")]
        public object? Notes { get; set; }
        [JsonProperty("invoice_date")]
        public object? InvoiceDate { get; set; }
        [JsonProperty("provider_inv_date")]
        public object? ProviderInvDate { get; set; }
        [JsonProperty("store_date")]
        public object? StoreDate { get; set; }
        [JsonProperty("branch_id")]
        public object? BranchId { get; set; }
        [JsonProperty("provider_id")]
        public object? ProviderId { get; set; }
        [JsonProperty("cost_ctr_id")]
        public object? CostCenterId { get; set; }
        [JsonProperty("invoice_type")]
        public object InvoiceType { get; set; }
        [JsonProperty("store_id")]
        public object? StoreId { get; set; }
        [JsonProperty("safe_id")]
        public object SafeId { get; set; }
        [JsonProperty("payment_type")]
        public object PaymentType { get; set; }
        [JsonProperty("pre_discount_total_amount")]
        public object PreDiscountTotalAmount { get; set; }
        [JsonProperty("pre_discount_total_vat")]
        public object PreDiscountTotalVat { get; set; }
        [JsonProperty("client_discount")]
        public object ClientDiscount { get; set; }
        [JsonProperty("total_discount")]
        public object TotalDiscount { get; set; }
        [JsonProperty("post_discount_total_amount")]
        public object PostDiscountTotalAmount { get; set; }
        [JsonProperty("total_vat")]
        public object TotalVat { get; set; }
        [JsonProperty("total_quantity")]
        public object TotalQuantity { get; set; }
        [JsonProperty("invoice_total_amount")]
        public object InvoiceTotalAmount { get; set; }
        [JsonProperty("paid_cash_amount")]
        public object PaidCashAmount { get; set; }
        [JsonProperty("paid_bank_amount")]
        public object PaidBankAmount { get; set; }
        [JsonProperty("company_id")]
        public object CompanyId { get; set; }
        [JsonProperty("user_id")]
        public object UserId { get; set; }
        [JsonProperty("bank_acc_id")]
        public object BankAccId { get; set; }
        [JsonProperty("paid_amount")]
        public object PaidAmount { get; set; }
        [JsonProperty("deferred_amount")]
        public object DeferredAmount { get; set; }
    }
}
