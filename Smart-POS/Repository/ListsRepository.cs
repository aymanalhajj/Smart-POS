using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp;
using Smart_POS.Models;

namespace Smart_POS.Repository
{
    public class ListsRepository
    {
        static public ObservableCollection<Item> Load_Branches()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/branch_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_Products()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/product_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_Stores()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/store_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_Saves()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/save_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_Banks()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();

            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/bank_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_CostCenters()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();

            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/cost_ctr_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }
        static public ObservableCollection<Item> Load_Providers()
        {
            ObservableCollection<Item> _list = new ObservableCollection<Item>();

            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/provider_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    _list.Add(item);
                }
            }
            return _list;
        }

    }
}
