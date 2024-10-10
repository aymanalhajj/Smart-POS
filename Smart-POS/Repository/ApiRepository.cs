using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Windows;
using Newtonsoft.Json;
using Smart_POS.Models;
using Smart_POS.View;

namespace Smart_POS.Repository
{
    public class ApiRepository
    {
        static ApiRepository _instance;
        string companyId = "0";
        string langId = "2";
        static private string baseUrl = "http://localhost:8000/ords/accounting/";
        //static private string baseUrl = "https://apex.oracle.com/pls/apex/smart_pos/";
        readonly HttpClient _client;
        static public ApiRepository getInstance()
        {
            if (_instance == null)
            {
                _instance = new ApiRepository();
            }
            return _instance;
        }

        public ApiRepository()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("token", "tokenaaaaa111222");
        }

        public ObservableCollection<Item> GetSelectList(Uri uri)
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            var response = _client.GetAsync(uri).Result;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Utils.ShowMessage("لايوجد بيانات.");
            }
            else
            {
                var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
                if (res != null)
                {
                    for (int i = 0; i < res.Items?.Count; i++)
                    {
                        _list.Add(res.Items[i]);
                    }
                }
            }
            return _list;
        }

        public ObservableCollection<Item> GetBranchList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/branch_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetProductList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/product_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetStoreList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/store_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetSaveList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/save_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetBankList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/bank_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetCostCenterList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/cost_ctr_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetProviderList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/provider_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetProductUnitList(string productId)
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/product_unit_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}" +
                $"&p_product_id={HttpUtility.UrlEncode(productId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }


        public InvoiceItemModel? GetProductUnitPrice(string productId, string quantity, string productUnitId)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"utils/get_product_unit_price" +
                    $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                    $"&p_product_id={HttpUtility.UrlEncode(productId)}" +
                    $"&p_quantity={HttpUtility.UrlEncode(quantity)}" +
                    $"&p_product_unit_id={HttpUtility.UrlEncode(productUnitId)}", UriKind.Absolute);
                var response = _client.GetAsync(requestUri).Result;
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
                    $"utils/get_product_price?p_company_id=0&" +
                    $"p_product_id={HttpUtility.UrlEncode(productId)}", UriKind.Absolute);
                var response = _client.GetAsync(requestUri).Result;
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
                    $"utils/get_product_by_barcode" +
                    $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                    $"&p_barcode={HttpUtility.UrlEncode(barcode)}", UriKind.Absolute);
                var response = _client.GetAsync(requestUri).Result;
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

        public ActionStatusModel PostPurchaseInoice(InvoiceModel model)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"invoices/purchase_invoice", UriKind.Absolute);

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _client.PostAsync(requestUri, data).Result;
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

        public InvoiceModel? GetPurchaseInvoice(string? first, string? last, string? next, string? prev, string? invoiceId)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"invoices/purchase_invoice?p_company_id=0&" +
                    $"p_first={HttpUtility.UrlEncode(first)}" +
                    $"&p_last={HttpUtility.UrlEncode(last)}" +
                    $"&p_next={HttpUtility.UrlEncode(next)}" +
                    $"&p_prev={HttpUtility.UrlEncode(prev)}" +
                    $"&p_invoice_id={HttpUtility.UrlEncode(invoiceId)}", UriKind.Absolute);
                var response = _client.GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<InvoiceModel>(response.Content.ReadAsStringAsync().Result);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
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

        public ObservableCollection<InvoiceListItemModel> GetAllPurchaseInoices()
        {
            ObservableCollection<InvoiceListItemModel> list = new ObservableCollection<InvoiceListItemModel>();
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"invoices/purchases_invoices", UriKind.Absolute);
                var response = _client.GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<InvoiceListModel>(response.Content.ReadAsStringAsync().Result);

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
