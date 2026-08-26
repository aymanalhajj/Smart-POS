using System;
using System.Collections.Generic;
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
        static protected string baseUrl = "https://localhost:7081/api/";
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
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
            };
            _client = new HttpClient(handler);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Accept-Language", "ar");
        }
        public void SetAuthToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public ObservableCollection<Item> GetSelectList(Uri uri)
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            try
            {
                var response = _client.GetAsync(uri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("لايوجد بيانات."+response.StatusCode);
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<List<Item>>(response.Content.ReadAsStringAsync().Result);
                    if (res != null)
                    {
                        for (int i = 0; i < res.Count; i++)
                        {
                            _list.Add(res[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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
        public ObservableCollection<Item> GetProviderList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/provider_list" +
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
        public ObservableCollection<Item> GetGroupList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/group_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetGroupTaxList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/tax_group_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetUnitList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/unit_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetTypeList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/type_list" +
                $"?p_company_id={HttpUtility.UrlEncode(companyId)}" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetCountryList()
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/country_list" +
                $"?p_company_id=0" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetCityList(string countryId)
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/city_list" +
                $"?p_company_id=0" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}" +
                $"&p_country_id={HttpUtility.UrlEncode(countryId)}", UriKind.Absolute);
            return GetSelectList(requestUri);
        }
        public ObservableCollection<Item> GetRegionList(string countryId, string cityId)
        {
            var requestUri = new Uri($"{baseUrl}" +
                $"lists/region_list" +
                $"?p_company_id=0" +
                $"&p_lang_id={HttpUtility.UrlEncode(langId)}" +
                $"&p_country_id={HttpUtility.UrlEncode(countryId)}" +
                $"&p_city_id={HttpUtility.UrlEncode(cityId)}", UriKind.Absolute);
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