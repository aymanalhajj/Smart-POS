using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class InvoiceModel
    {

        [JsonProperty("order_id")]
        public int OrderId;

        [JsonProperty("order_no")]
        public object OrderNo;

        [JsonProperty("invoice_id")]
        public int InvoiceId;
        [JsonProperty("invoice_no")]
        public int InvoiceNo;
        [JsonProperty("provider_inv_id")]
        public object? ProviderInvId;
        [JsonProperty("notes")]
        public object? Notes; 
        [JsonProperty("order_date")]
        public object? OrderDate;
        [JsonProperty("invoice_date")]
        public object? InvoiceDate;
        [JsonProperty("provider_inv_date")]
        public object? ProviderInvDate;
        [JsonProperty("store_date")]
        public object? StoreDate;
        [JsonProperty("branch_id")]
        public object? BranchId; 
        [JsonProperty("provider_id")]
        public object? ProviderId;
        [JsonProperty("client_id")]
        public object? ClientId;
        [JsonProperty("cost_ctr_id")]
        public object? CostCenterId;
        [JsonProperty("invoice_type")]
        public int InvoiceType;
        [JsonProperty("store_id")]
        public object? StoreId;
        [JsonProperty("safe_id")]
        public object SafeId;
        [JsonProperty("payment_type")]
        public int PaymentType;
        [JsonProperty("pre_discount_total_amount")]
        public double PreDiscountTotalAmount;
        [JsonProperty("pre_discount_total_vat")]
        public double PreDiscountTotalVat;
        [JsonProperty("client_discount")]
        public float ClientDiscount;
        [JsonProperty("total_discount")]
        public double TotalDiscount;
        [JsonProperty("post_discount_total_amount")]
        public double PostDiscountTotalAmount;
        [JsonProperty("total_vat")]
        public double TotalVat;
        [JsonProperty("total_quantity")]
        public int TotalQuantity;
        [JsonProperty("invoice_total_amount")]
        public double InvoiceTotalAmount;
        [JsonProperty("paid_cash_amount")]
        public double PaidCashAmount;
        [JsonProperty("paid_bank_amount")]
        public double PaidBankAmount;
        [JsonProperty("company_id")]
        public int CompanyId;
        [JsonProperty("user_id")]
        public int UserId;
        [JsonProperty("bank_acc_id")]
        public object? BankAccId;
        [JsonProperty("paid_amount")]
        public double PaidAmount;
        [JsonProperty("deferred_amount")]
        public double DeferredAmount;
        [JsonProperty("items")]
        public List<InvoiceItemModel>? Items;
    }

}
