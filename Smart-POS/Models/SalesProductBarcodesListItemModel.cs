using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductBarcodesListItemModel
    {
        public object ProductBarcodeId { get; set; }

        public string ProductId { get; set; }

        public object Barcode { get; set; }

        public object CompanyId { get; set; }

        public string ProductNameAr { get; set; }

        public string ProductNameEn { get; set; }
    }
}
