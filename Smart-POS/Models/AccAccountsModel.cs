using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccAccountsModel
    {
        public object AccountId { get; set; }

        public string AccountNameAr { get; set; }

        public object AccountNature { get; set; }

        public object AccountType { get; set; }

        public object AccountParent { get; set; }

        public string SubAccount { get; set; }

        public object AccountLevel { get; set; }

        public object AccDate { get; set; }

        public object CompanyId { get; set; }

        public string AccountNameEn { get; set; }
    }
}
