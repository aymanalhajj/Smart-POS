using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class StoreTransferModel
    {

        [JsonProperty("transfer_id")]
        public int TransferId;
      
        [JsonProperty("from_store_id")]
        public object FromStoreId;

        [JsonProperty("to_store_id")]
        public object ToStoreId;

        [JsonProperty("transfer_date")]
        public object TransferDate;

        [JsonProperty("transfer_by")]
        public object? TransferBy;

        [JsonProperty("has_received")]
        public int HasReceived;

        [JsonProperty("receive_date")]
        public object ReceiveDate;

        [JsonProperty("received_by")]
        public object? ReceivedBy;

        [JsonProperty("company_id")]
        public int CompanyId;

        [JsonProperty("transfer_no")]
        public int TransferNo;

        [JsonProperty("branch_id")]
        public object BranchId;

        [JsonProperty("items")]
        public List<StockItemModel>? Items;
    }
}
