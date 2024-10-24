using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Windows;
using Newtonsoft.Json;
using Smart_POS.Models;

namespace Smart_POS.Repository
{
    public class ApiRepository
    {
        static ApiRepository _instance;
        public string companyId = "1";
        string langId = "2";
        static protected string baseUrl = "http://localhost:8000/ords/accounting/";
        //static private string baseUrl = "https://apex.oracle.com/pls/apex/smart_pos/";
        readonly HttpClient _client;
        public HttpClient MyClient()
        {
            return _client;
        }
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
        public ObservableCollection<Item> GetAccountList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/account_list" +
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
        
        public ObservableCollection<Item> GetClientList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/client_list" +
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

    }
}
