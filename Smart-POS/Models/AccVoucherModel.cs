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
        public int AccVoucherId;

        public decimal? Amount;

        public object AccountId;

        public object? RefId;

        public int? PaymentMethod;

        public object? PaidTo;

        public object VoucherDate;

        public int Posted;

        public int VoucherType;

        public object? Note;

        public int? CheckNo;

        public object CheckDate;

        public object? CostCntrId;

        public int CompanyId;

        public decimal? TotalVat;

        public List<AccVoucherItemModel>? Items;
    }
}
