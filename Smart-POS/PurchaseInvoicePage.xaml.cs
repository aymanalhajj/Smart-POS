using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using POS_Desktop.Models;
using Smart_POS.ViewModel;
using static POS_Desktop.PurchaseInvoicePage;
using MessageBox = System.Windows.MessageBox;

namespace POS_Desktop
{

    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int integer = (int)value;
            if (integer == int.Parse(parameter.ToString()))
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    /// <summary>
    /// Interaction logic for PurchaseInvoicePage.xaml
    /// </summary>
    public partial class PurchaseInvoicePage : Window
    {
        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedValue != null && !comboBox.SelectedValue.Equals(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId))
            {
                //MessageBox.Show(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId.ToString());

                viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId = comboBox?.SelectedValue.ToString();
                viewModel.ProductSelected();
            }
        }
        public static bool BooleanTrue = true;

        public static bool BooleanFalse = false;
        PurchaseInvoiceViewModel viewModel;

        public PurchaseInvoicePage()
        {
            viewModel = new PurchaseInvoiceViewModel();
            DataContext = viewModel;

            InitializeComponent();

            ProductComboBox.ItemsSource = viewModel.ProductList;
            //ProductUnitComboBox.ItemsSource = viewModel.ProductList;

            Load_Branches();
            Load_Providers();
            Load_CostCenters();
            Load_Saves();
            Load_Stores();
            Load_InvoiceTypes();

            Load_Products();
            Load_PaymentTypes();
            Load_Banks();

        }

        private void Load_Branches()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/branch_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    BranchList.Items.Add(item);
                }
            }
        }

        private void Load_Stores()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/store_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    StoreList.Items.Add(item);
                }
            }
        }

        private void Load_Saves()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/save_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    SaveList.Items.Add(item);
                }
            }
        }

        private void Load_Banks()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/bank_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    BankList.Items.Add(item);
                }
            }
        }

        private void Load_CostCenters()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/cost_ctr_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    CostCenterList.Items.Add(item);
                }
            }
        }

        private void Load_InvoiceTypes()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/invoice_type_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    //InvoiceTypeList.Items.Add(item);
                }
            }
        }

        private void Load_PaymentTypes()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/payment_type_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    //PaymentTypeList.Items.Add(item);
                }
            }
        }

        private void Load_Products()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/product_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    viewModel.ProductList.Add(item);
                }

            }
        }
        private void Load_Providers()
        {
            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/lists/provider_list?p_lang_id=2&p_company_id=0").Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    ProviderList.Items.Add(item);
                }
            }
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId.ToString());

                MessageBox.Show(viewModel.CurrentRow.ToString());
                //MessageBox.Show(viewModel.InvoiceDetailItems.Count.ToString());
                /*
                                viewModel.PurchaseInvoice.items = viewModel.InvoiceDetailItems;


                                var json = JsonConvert.SerializeObject(viewModel.PurchaseInvoice);
                                var data = new StringContent(json, Encoding.UTF8, "application/json");

                                using var client = new HttpClient();
                                var response = client.PostAsync($"http://localhost:8000/ords/accounting/invoices/purchase_invoice", data).Result;

                                var res = JsonConvert.DeserializeObject<LoginResponseModel>(response.Content.ReadAsStringAsync().Result);

                                MessageBox.Show(response.StatusCode.ToString());
                                if (res != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    MessageBox.Show(response.StatusCode.ToString());
                                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DetailsGrid.Items.Count.ToString());
            if (viewModel.CurrentRow >= 0 && viewModel.InvoiceDetailItems.Count > 0 && viewModel.CurrentRow < viewModel.InvoiceDetailItems.Count)
            {
                viewModel.InvoiceDetailItems.RemoveAt(viewModel.CurrentRow);
            }
        }

        private void DetailsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.DisplayIndex == 2 || e.Column.DisplayIndex == 4 || e.Column.DisplayIndex == 6 || e.Column.DisplayIndex == 9)
            {
                viewModel.RecalcPrice();
            }
            if (e.Column.DisplayIndex == 12)
            {
                viewModel.ChangePrice();
            }
            //MessageBox.Show(e.Column.DisplayIndex.ToString());
        }

        private void deferredInvoiceBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (deferredInvoiceBtn.IsChecked == true)
            {
                PaidAmountTxt.IsReadOnly = false;
                DeferredAmountTxt.IsReadOnly = false;
            }
            else
            {
                PaidAmountTxt.IsReadOnly = true;
                DeferredAmountTxt.IsReadOnly = true;
            }
        }

        private void bankBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (bankBtn.IsChecked == true)
            {
                PaidCashTxt.IsReadOnly = false; 
                PaidBankTxt.IsReadOnly = false;
                BankList.IsEnabled = true;
            }
            else
            {
                PaidCashTxt.IsReadOnly = true;
                PaidBankTxt.IsReadOnly = true;
                BankList.IsEnabled = false;
            }


        }
    }
}
