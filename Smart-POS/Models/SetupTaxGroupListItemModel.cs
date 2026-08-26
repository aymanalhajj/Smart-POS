using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupTaxGroupListItemModel
    {
        public object GroupId { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public string GroupValue { get; set; }

        public string Status { get; set; }

        public object CompanyId { get; set; }
    }
}
