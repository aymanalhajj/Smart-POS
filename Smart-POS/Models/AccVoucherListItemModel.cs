using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccVoucherListItemModel
    {
        public int AccVoucherId;

        public object Amount;

        public object AccountId;

        public object RefId;

        public object? PaymentMethod;

        public object? PaidTo;

        public object? VoucherDate;

        public object? Posted;

        public object? VoucherType;

        public object? Note;

        public object? CheckNo;

        public object? CheckDate;

        public object? CostCntrId;

        public object? CompanyId;

        public object? TotalVat;
    }
}
