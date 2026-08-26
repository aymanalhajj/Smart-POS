using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductUnitListItemModel
    {
        public object ProductUnitId { get; set; }

        public string ProductId { get; set; }

        public string UnitId { get; set; }

        public string UnitValue { get; set; }

        public object PurchasePrice { get; set; }

        public object SellPrice { get; set; }

        public object Barcode { get; set; }

        public object CompanyId { get; set; }

        public string ProductNameAr { get; set; }

        public string ProductNameEn { get; set; }

        public string UnitNameAr { get; set; }

        public string UnitNameEn { get; set; }

        public string CompanyNameAr { get; set; }

        public string CompanyNameEn { get; set; }
    }
}
