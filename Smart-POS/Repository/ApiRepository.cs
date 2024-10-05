using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Smart_POS.Repository
{
    internal class ApiRepository
    {
        public ApiRepository()
        {
        }
        static private string baseUrl = "http://localhost:8000/";
        static private string _getProductPriceByIdUri = "ords/accounting/utils/get_product_price?p_company_id=0&";
        static public Uri GetProductPriceByIdUri(string productId)
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"{_getProductPriceByIdUri}" +
                $"p_product_id={HttpUtility.UrlEncode(productId)}", UriKind.Absolute);
            return requestUri;
        }

    }
}
