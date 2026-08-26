using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class AccAccountsListItemModel
    {
        public object AccountId { get; set; }

        public string AccountNameAr { get; set; }

        public object AccountNature { get; set; }

        public object AccountType { get; set; }

        public object AccountParent { get; set; }

        public object SubAccount { get; set; }

        public object AccountLevel { get; set; }

        public object AccDate { get; set; }

        public object CompanyId { get; set; }

        public object AccountNameEn { get; set; }
    }
    public class TreeAccountsListItemModel
    {
        public object Status { get; set; }

        public object Level { get; set; }

        public string Title { get; set; }

        public object Value { get; set; }

        public object ParentId { get; set; }
    }
}
