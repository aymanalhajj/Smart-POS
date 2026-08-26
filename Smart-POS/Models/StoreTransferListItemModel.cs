using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class StoreTransferListItemModel
    {
        public int TransferId;

        public object FromStoreId;

        public object ToStoreId;

        public object TransferDate;

        public object? TransferBy;

        public object? HasReceived;

        public object? ReceiveDate;

        public object? ReceivedBy;

        public object? CompanyId;

        public object? TransferNo;

        public object? BranchId;
    }
}
