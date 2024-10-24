﻿using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Smart_POS.Models;
using System.Web;

namespace Smart_POS.Repository
{
    internal class StockOutOrderRepo : ApiRepository
    {

        public InvoiceItemModel? GetProductUnitPrice(string productId, string quantity, string productUnitId)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"utils/get_product_unit_sell_price" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}" +
                    $"&p_product_id={HttpUtility.UrlEncode(productId)}" +
                    $"&p_quantity={HttpUtility.UrlEncode(quantity)}" +
                    $"&p_product_unit_id={HttpUtility.UrlEncode(productUnitId)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }


        public InvoiceItemModel? GetProductPrice(string productId)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"utils/get_product_sell_price" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}" +
                    $"&p_product_id={HttpUtility.UrlEncode(productId)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }

        public InvoiceItemModel? GetProductPriceByBarcode(string barcode)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"utils/get_product_sell_price_by_barcode" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}" +
                    $"&p_barcode={HttpUtility.UrlEncode(barcode)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }

        public ActionStatusModel PostPurchaseInoice(StockModel model)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"store/stockout_order", UriKind.Absolute);

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = ApiRepository.getInstance().MyClient().PostAsync(requestUri, data).Result;
                //var res = JsonConvert.DeserializeObject<LoginResponseModel>(response.Content.ReadAsStringAsync().Result);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new ActionStatusModel("لم يتم الحفظ", status: 0);
                }
                else
                {
                    return new ActionStatusModel(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }

        public StockModel? GetPurchaseInvoice(string? first, string? last, string? next, string? prev, string? invoiceId)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"store/stockout_order" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}" +
                    $"&p_first={HttpUtility.UrlEncode(first)}" +
                    $"&p_last={HttpUtility.UrlEncode(last)}" +
                    $"&p_next={HttpUtility.UrlEncode(next)}" +
                    $"&p_prev={HttpUtility.UrlEncode(prev)}" +
                    $"&p_invoice_id={HttpUtility.UrlEncode(invoiceId)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<StockModel>(response.Content.ReadAsStringAsync().Result);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول."+ response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }

        public ObservableCollection<StockListItemModel> GetAllPurchaseInoices()
        {
            ObservableCollection<StockListItemModel> list = new ObservableCollection<StockListItemModel>();
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"store/stockout_orders", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<StockListModel>(response.Content.ReadAsStringAsync().Result);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
                }
                else
                {
                    if (res != null)
                    {
                        foreach (var item in res.items)
                        {
                            list.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return list;
        }
    }
}
