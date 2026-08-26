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
        public int TransferId;

        public object FromStoreId;

        public object ToStoreId;

        public object TransferDate;

        public object? TransferBy;

        public int HasReceived;

        public object ReceiveDate;

        public object? ReceivedBy;

        public int CompanyId;

        public int TransferNo;

        public object BranchId;

        public List<StockItemModel>? Items;
    }
}
