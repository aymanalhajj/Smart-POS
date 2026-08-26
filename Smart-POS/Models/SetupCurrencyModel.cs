using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupCurrencyModel
    {
        public object CurrencyId { get; set; }

        public string CodeAr { get; set; }

        public string NameAr { get; set; }

        public string CreatedBy { get; set; }

        public object CreatedAt { get; set; }

        public object ModifiedBy { get; set; }

        public object ModifiedAt { get; set; }

        public object CompanyId { get; set; }

        public string NameEn { get; set; }

        public string CodeEn { get; set; }
    }
}
