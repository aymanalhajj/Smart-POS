using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class ProductModel
    {
        public object ProductId { get; set; }

        public string ProductNameAr { get; set; }

        public string ProductNameEn { get; set; }

        public string Barcode { get; set; }

        public string TypeId { get; set; }

        public string TaxGroupId { get; set; }

        public string TaxValue { get; set; }

        public string DefaultUnitId { get; set; }

        public object ProductGroupId { get; set; }

        public object PurchasePrice { get; set; }

        public object SellPrice { get; set; }

        public string ProviderId { get; set; }

        public string ProductStatus { get; set; }

        public object CompanyId { get; set; }

        public string ProductNo { get; set; }

        public string TaxGroupNameAr { get; set; }

        public string TaxGroupNameEn { get; set; }

        public string UnitNameAr { get; set; }

        public string UnitNameEn { get; set; }

        public string ProductGroupNameAr { get; set; }

        public string ProductGroupNameEn { get; set; }

        public string ProviderNameAr { get; set; }

        public string ProviderNameEn { get; set; }

        public string CompanyNameAr { get; set; }

        public string CompanyNameEn { get; set; }
    }
}
