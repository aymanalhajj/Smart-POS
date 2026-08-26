using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SetupBankListItemModel
    {
        public object BankAccId { get; set; }

        public string AccNameAr { get; set; }

        public string AccountId { get; set; }

        public string TelNo { get; set; }

        public object MobileNo { get; set; }

        public object CountryId { get; set; }

        public object CityId { get; set; }

        public object RegionId { get; set; }

        public string Note { get; set; }

        public string ForAllBranches { get; set; }

        public string Status { get; set; }

        public object CompanyId { get; set; }

        public string AccNameEn { get; set; }

        public string CountryNameAr { get; set; }

        public string CountryNameEn { get; set; }

        public string CityNameAr { get; set; }

        public string CityNameEn { get; set; }

        public string RegionNameAr { get; set; }

        public string RegionNameEn { get; set; }
    }
}
