using Newtonsoft.Json;
using Smart_POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Web;
using System.Windows.Documents;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;

namespace Smart_POS.Repository
{
    internal class SalesProductBarcodesRepo : ApiRepository
    {
        public ObservableCollection<SalesProductBarcodesListItemModel> GetAll()
        {
            ObservableCollection<SalesProductBarcodesListItemModel> list = new ObservableCollection<SalesProductBarcodesListItemModel>();
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"setup/product_barcodes" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<List<SalesProductBarcodesListItemModel>>(response.Content.ReadAsStringAsync().Result);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول.");
                }
                else
                {
                    if (res != null)
                    {
                        foreach (var item in res)
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
        public SalesProductBarcodesModel Get(string? first, string? last, string? next, string? prev, string? Id)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"setup/product_barcode" +
                    $"?p_company_id={HttpUtility.UrlEncode(ApiRepository.getInstance().companyId)}" +
                    $"&p_first={HttpUtility.UrlEncode(first)}" +
                    $"&p_last={HttpUtility.UrlEncode(last)}" +
                    $"&p_next={HttpUtility.UrlEncode(next)}" +
                    $"&p_prev={HttpUtility.UrlEncode(prev)}" +
                    $"&p_id={HttpUtility.UrlEncode(Id)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول."+ response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<SalesProductBarcodesModel>(response.Content.ReadAsStringAsync().Result);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
            }
            return null;
        }
        public ActionStatusModel Post(SalesProductBarcodesModel model)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"setup/product_barcode", UriKind.Absolute);

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = ApiRepository.getInstance().MyClient().PostAsync(requestUri, data).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new ActionStatusModel("لم يتم الحفظ"+response.Content.ReadAsStringAsync().Result, status: 0);
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
        public ActionStatusModel Delete(string Id)
        {
            try
            {
                var requestUri = new Uri($"{baseUrl}" +
                    $"setup/product_barcode/{HttpUtility.UrlEncode(Id)}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().DeleteAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new ActionStatusModel("لم يتم الحذف", status: 0);
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
    }
}