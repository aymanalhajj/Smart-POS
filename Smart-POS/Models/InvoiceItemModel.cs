using Newtonsoft.Json;

namespace Smart_POS.Models
{
    public class InvoiceItemModel
    {   
        [JsonProperty("dtl_id")]
        public string? Dtl_Id { get; set; }

        [JsonProperty("product_id")]
        public string? ProductId { get; set; }

        [JsonProperty("barcode")]
        public string? ProductBarcode { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit_id")]
        public string ProductUnitId { get; set; }

        [JsonProperty("base_price")]
        public float? Price { get; set; }

        [JsonProperty("total_price")]
        public string? TotalPrice { get; set; }

        [JsonProperty("discount_percentage")]
        public float? DiscountPercentage { get; set; }

        [JsonProperty("discount_value")]
        public string? DiscountValue { get; set; }

        [JsonProperty("post_discount_total_price")]
        public string? PostDiscountPrice { get; set; }

        [JsonProperty("vat_percentage")]
        public float? VatPercentage { get; set; }

        [JsonProperty("vat_value")]
        public string? VatValue { get; set; }

        [JsonProperty("total_amount")]
        public string? TotalAmount { get; set; }

        [JsonProperty("pre_discount_vat_value")]
        public string? PreDiscountVatValue;
        [JsonProperty("original_price")]
        public string? OriginalPrice;
    }
}
