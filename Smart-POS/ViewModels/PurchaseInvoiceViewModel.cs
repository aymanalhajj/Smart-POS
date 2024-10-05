using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using POS_Desktop.Models;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    class PurchaseInvoiceViewModel : INotifyPropertyChanged
    {

        public int CurrentRow { get; set; }
        private InvoiceViewModel invoice;

        private ObservableCollection<Item> _productList;
        private ObservableCollection<Item> _branchList;
        private ObservableCollection<Item> _storeList;
        private ObservableCollection<Item> _saveList;
        private ObservableCollection<Item> _bankList;
        private ObservableCollection<Item> _costCenterList;
        private ObservableCollection<Item> _providerList;

        public ObservableCollection<Item> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged("ProductList");
            }
        }
        public ObservableCollection<Item> BranchList
        {
            get { return _branchList; }
            set
            {
                _branchList = value;
                OnPropertyChanged("BranchList");
            }
        }
        public ObservableCollection<Item> StoreList
        {
            get { return _storeList; }
            set
            {
                _storeList = value;
                OnPropertyChanged("StoreList");
            }
        }
        public ObservableCollection<Item> SaveList
        {
            get { return _saveList; }
            set
            {
                _saveList = value;
                OnPropertyChanged("SaveList");
            }
        }
        public ObservableCollection<Item> BankList
        {
            get { return _bankList; }
            set
            {
                _bankList = value;
                OnPropertyChanged("BankList");
            }
        }
        public ObservableCollection<Item> CostCenterList
        {
            get { return _costCenterList; }
            set
            {
                _costCenterList = value;
                OnPropertyChanged("CostCenterList");
            }
        }
        public ObservableCollection<Item> ProviderList
        {
            get { return _providerList; }
            set
            {
                _providerList = value;
                OnPropertyChanged("ProviderList");
            }
        }

        public InvoiceViewModel Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }
        private ObservableCollection<InvoiceItemViewModel> _InvoiceDetailItems;


        public ObservableCollection<InvoiceItemViewModel> InvoiceDetailItems
        {
            get { return _InvoiceDetailItems; }
            set
            {
                _InvoiceDetailItems = value;
                OnPropertyChanged("InvoiceDetailItems");
            }
        }
        public PurchaseInvoiceViewModel()
        {
            _InvoiceDetailItems = new ObservableCollection<InvoiceItemViewModel> { };
            ProductList = new ObservableCollection<Item> { };

            BranchList = new ObservableCollection<Item> { };
            StoreList = new ObservableCollection<Item> { };
            SaveList = new ObservableCollection<Item> { };
            BankList = new ObservableCollection<Item> { };
            CostCenterList = new ObservableCollection<Item> { };
            ProviderList = new ObservableCollection<Item> { };

            invoice = new InvoiceViewModel();
            invoice.ResetPaidCallback += new InvoiceViewModel.ResetPaidCallbackEventHandler(resetPaid);
            invoice.DiscountCallback += new InvoiceViewModel.DiscountCallbackEventHandler(DistributeDiscount);
            invoice.ResetPaidCashCallback += new InvoiceViewModel.ResetPaidCashCallbackEventHandler(resetCashBankPaid);

            CurrentRow = 0;
            
            initLists();
        }

        public ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(o => SaveBtnClick());
                }
                return _SaveCommand;
            }
        }
        private void SaveBtnClick()
        {
            try
            {
                //MessageBox.Show(InvoiceDetailItems[CurrentRow].ProductId.ToString());

                //MessageBox.Show(CurrentRow.ToString());
                //MessageBox.Show(viewModel.InvoiceDetailItems.Count.ToString());

                //PurchaseInvoice.items = InvoiceDetailItems.ToList<InvoiceDetailItem>();


                var json = JsonConvert.SerializeObject(ToInvoiceModel());
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient();
                var response = client.PostAsync($"http://localhost:8000/ords/accounting/invoices/purchase_invoice", data).Result;

                var res = JsonConvert.DeserializeObject<LoginResponseModel>(response.Content.ReadAsStringAsync().Result);

                MessageBox.Show(response.StatusCode.ToString());
                MessageBox.Show(response.Content.ReadAsStringAsync().Result);
                if (res != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Done.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void initLists()
        {
            BranchList = ListsRepository.Load_Branches();
            ProviderList = ListsRepository.Load_Providers();
            CostCenterList = ListsRepository.Load_CostCenters();
            SaveList = ListsRepository.Load_Saves();
            StoreList = ListsRepository.Load_Stores();
            BankList = ListsRepository.Load_Banks();
            ProductList = ListsRepository.Load_Products();
        }


        public void GetProductPrice()
        {
            try
            {

                InvoiceDetailItems[CurrentRow].Load_ProductUnits();
                InvoiceDetailItems[CurrentRow].CalcSummaryCallback += new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(calcSummary);

                using var client = new HttpClient();
                //var requestUri = new Uri($"http://localhost:8000/ords/accounting/utils/get_product_price?p_company_id=0&p_product_id={HttpUtility.UrlEncode(InvoiceDetailItems[CurrentRow].ProductId.ToString())}", UriKind.Absolute);
                var requestUri = ApiRepository.GetProductPriceByIdUri(InvoiceDetailItems[CurrentRow].ProductId.ToString());
                var response = client.GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
                if (res != null)
                {
                    InvoiceDetailItems[CurrentRow].ProductBarcode = res.Barcode;
                    InvoiceDetailItems[CurrentRow].Quantity = res.Quantity;
                    InvoiceDetailItems[CurrentRow].ProductUnitId = res.UnitId;
                    InvoiceDetailItems[CurrentRow].Price = res.BasePrice;
                    InvoiceDetailItems[CurrentRow].TotalPrice = res.TotalPrice;
                    InvoiceDetailItems[CurrentRow].DiscountPercentage = res.DiscountPercentage;
                    InvoiceDetailItems[CurrentRow].VatPercentage = res.VatPercentage;
                    InvoiceDetailItems[CurrentRow].DiscountValue = res.DiscountValue;
                    InvoiceDetailItems[CurrentRow].PostDiscountPrice = res.PostDiscountTotalPrice;
                    InvoiceDetailItems[CurrentRow].VatValue = res.VatValue;
                    InvoiceDetailItems[CurrentRow].PreDiscountVatValue = res.PreDiscountVatValue;
                    InvoiceDetailItems[CurrentRow].TotalAmount = res.TotalAmount;
                    InvoiceDetailItems[CurrentRow].OriginalPrice = res.OriginalPrice;
                    calcSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetProductPriceByBarcode(string productBarcode)
        {
            try
            {
                using var client = new HttpClient();
                var requestUri = new Uri($"http://localhost:8000/ords/accounting/utils/get_product_by_barcode?p_company_id=0&p_barcode={HttpUtility.UrlEncode(productBarcode)}", UriKind.Absolute);

                var response = client.GetAsync(requestUri).Result;
                var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
                if (res != null)
                {
                    InvoiceDetailItems[CurrentRow].ProductId = res.ProductId;
                    InvoiceDetailItems[CurrentRow].Quantity = res.Quantity;
                    InvoiceDetailItems[CurrentRow].Price = res.BasePrice;
                    InvoiceDetailItems[CurrentRow].TotalPrice = res.TotalPrice;
                    InvoiceDetailItems[CurrentRow].DiscountPercentage = res.DiscountPercentage;
                    InvoiceDetailItems[CurrentRow].DiscountValue = res.DiscountValue;
                    InvoiceDetailItems[CurrentRow].PostDiscountPrice = res.PostDiscountTotalPrice;
                    InvoiceDetailItems[CurrentRow].VatPercentage = res.VatPercentage;
                    InvoiceDetailItems[CurrentRow].VatValue = res.VatValue;
                    InvoiceDetailItems[CurrentRow].PreDiscountVatValue = res.PreDiscountVatValue;
                    InvoiceDetailItems[CurrentRow].TotalAmount = res.TotalAmount;
                    InvoiceDetailItems[CurrentRow].OriginalPrice = res.OriginalPrice;

                    InvoiceDetailItems[CurrentRow].Load_ProductUnits();
                    InvoiceDetailItems[CurrentRow].ProductUnitId = res.UnitId;

                    //purchaseInvoice.ClientDiscount = 0;
                    calcSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetProductUnitPrice()
        {
            using var client = new HttpClient();

            var requestUri = new Uri($"http://localhost:8000/ords/accounting/utils/get_product_unit_price?p_company_id=0&p_product_id={HttpUtility.UrlEncode(InvoiceDetailItems[CurrentRow].ProductId.ToString())}&p_quantity={HttpUtility.UrlEncode(InvoiceDetailItems[CurrentRow].Quantity.ToString())}&p_product_unit_id={HttpUtility.UrlEncode(InvoiceDetailItems[CurrentRow].ProductUnitId.ToString())}", UriKind.Absolute);

            var response = client.GetAsync(requestUri).Result;
            var res = JsonConvert.DeserializeObject<InvoiceItemModel>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                InvoiceDetailItems[CurrentRow].Price = res.BasePrice;
                InvoiceDetailItems[CurrentRow].TotalPrice = res.TotalPrice;
                InvoiceDetailItems[CurrentRow].DiscountPercentage = res.DiscountPercentage;
                InvoiceDetailItems[CurrentRow].DiscountValue = res.DiscountValue;
                InvoiceDetailItems[CurrentRow].PostDiscountPrice = res.PostDiscountTotalPrice;
                InvoiceDetailItems[CurrentRow].VatPercentage = res.VatPercentage;
                InvoiceDetailItems[CurrentRow].VatValue = res.VatValue;
                InvoiceDetailItems[CurrentRow].PreDiscountVatValue = res.PreDiscountVatValue;
                InvoiceDetailItems[CurrentRow].TotalAmount = res.TotalAmount;
                InvoiceDetailItems[CurrentRow].OriginalPrice = res.OriginalPrice;

                //purchaseInvoice.ClientDiscount = 0;
                calcSummary();
            }
        }
        public void DistributeDiscount(float DiscountPercent)
        {
            for (int i = 0; i < InvoiceDetailItems.Count; i++)
            {
                InvoiceDetailItems[i].DiscountPercentage = DiscountPercent;
                //InvoiceDetailItems[i].DiscountValue = (float.Parse(InvoiceDetailItems[i].TotalPrice) * InvoiceDetailItems[i].DiscountPercentage / 100).ToString();
                //InvoiceDetailItems[i].PostDiscountPrice = (float.Parse(InvoiceDetailItems[i].TotalPrice) - float.Parse(InvoiceDetailItems[i].DiscountValue)).ToString(); ;
                //InvoiceDetailItems[i].VatValue = (float.Parse(InvoiceDetailItems[i].PostDiscountPrice) * InvoiceDetailItems[i].VatPercentage / 100).ToString();
                //InvoiceDetailItems[i].TotalAmount = Math.Round((float.Parse(InvoiceDetailItems[i].PostDiscountPrice) + float.Parse(InvoiceDetailItems[i].VatValue)), 2).ToString();
            }
            calcSummary();
        }
        public void RecalcPrice()
        {
            if (InvoiceDetailItems[CurrentRow].ProductId != null && InvoiceDetailItems[CurrentRow].ProductId != "")
            {
                //purchaseInvoice.ClientDiscount = 0;
                InvoiceDetailItems[CurrentRow].TotalPrice = (float.Parse(InvoiceDetailItems[CurrentRow].Price) * float.Parse(InvoiceDetailItems[CurrentRow].Quantity)).ToString();
                InvoiceDetailItems[CurrentRow].PreDiscountVatValue = (float.Parse(InvoiceDetailItems[CurrentRow].TotalPrice) * InvoiceDetailItems[CurrentRow].VatPercentage / 100).ToString();
                InvoiceDetailItems[CurrentRow].DiscountValue = (float.Parse(InvoiceDetailItems[CurrentRow].TotalPrice) * InvoiceDetailItems[CurrentRow].DiscountPercentage / 100).ToString();
                InvoiceDetailItems[CurrentRow].PostDiscountPrice = (float.Parse(InvoiceDetailItems[CurrentRow].TotalPrice) - float.Parse(InvoiceDetailItems[CurrentRow].DiscountValue)).ToString(); ;
                InvoiceDetailItems[CurrentRow].VatValue = (float.Parse(InvoiceDetailItems[CurrentRow].PostDiscountPrice) * InvoiceDetailItems[CurrentRow].VatPercentage / 100).ToString();
                InvoiceDetailItems[CurrentRow].TotalAmount = Math.Round((float.Parse(InvoiceDetailItems[CurrentRow].PostDiscountPrice) + float.Parse(InvoiceDetailItems[CurrentRow].VatValue)), 2).ToString();
                calcSummary();
            }
        }
        public void calcSummary()
        {
            invoice.PreDiscountTotalAmount = 0;
            invoice.TotalDiscount = 0;
            invoice.PostDiscountTotalAmount = 0;
            invoice.TotalVat = 0;
            invoice.PreDiscountTotalVat = 0;
            invoice.TotalQuantity = 0;
            invoice.InvoiceTotalAmount = 0;
            foreach (var item in InvoiceDetailItems)
            {
                invoice.PreDiscountTotalAmount += double.Parse(item.TotalPrice);
                invoice.TotalDiscount += double.Parse(item.DiscountValue);
                invoice.PostDiscountTotalAmount += double.Parse(item.PostDiscountPrice);
                invoice.TotalVat += double.Parse(item.VatValue);
                invoice.PreDiscountTotalVat += double.Parse(item.PreDiscountVatValue);
                invoice.TotalQuantity += int.Parse(item.Quantity);
                invoice.InvoiceTotalAmount += double.Parse(item.TotalAmount);

            }
            invoice.PreDiscountTotalAmount = Math.Round(invoice.PreDiscountTotalAmount, 6);
            invoice.TotalDiscount = Math.Round(invoice.TotalDiscount, 6);
            invoice.PostDiscountTotalAmount = Math.Round(invoice.PostDiscountTotalAmount, 6);
            invoice.TotalVat = Math.Round(invoice.TotalVat, 6);
            invoice.PreDiscountTotalVat = Math.Round(invoice.PreDiscountTotalVat, 6);
            invoice.InvoiceTotalAmount = Math.Round(invoice.InvoiceTotalAmount, 6);
            resetPaid();
        }
        public void resetPaid()
        {
            invoice.PaidAmount = invoice.InvoiceTotalAmount;
            invoice.DeferredAmount = 0;

            resetCashBankPaid();
        }
        public void resetCashBankPaid()
        {
            invoice.PaidCashAmount = invoice.PaidAmount;
            invoice.PaidBankAmount = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        public InvoiceModel ToInvoiceModel()
        {
            InvoiceModel model = new()
            {
                BankAccId = invoice.BankAccId,
                BranchId = invoice.BranchId,
                ClientDiscount = invoice.ClientDiscount,
                CompanyId = invoice.CompanyId,
                CostCenterId = invoice.CostCenterId,
                DeferredAmount = invoice.DeferredAmount,
                InvoiceDate = String.Format("{0:dd-MM-yyyy}",invoice.InvoiceDate),
                InvoiceId = invoice.InvoiceId,
                InvoiceNo = invoice.InvoiceNo,
                InvoiceTotalAmount = invoice.InvoiceTotalAmount,
                InvoiceType = invoice.InvoiceType,
                Notes = invoice.Notes,
                PaidAmount = invoice.PaidAmount,
                PaidBankAmount = invoice.PaidBankAmount,
                PaymentType = invoice.PaymentType,
                PostDiscountTotalAmount = invoice.PostDiscountTotalAmount,
                PreDiscountTotalAmount = invoice.PreDiscountTotalAmount,
                PreDiscountTotalVat = invoice.PreDiscountTotalVat,
                ProviderId = invoice.ProviderId,
                ProviderInvDate = String.Format("{0:dd-MM-yyyy}", invoice.ProviderInvDate),
                ProviderInvId = invoice.ProviderInvId,
                SafeId = invoice.SafeId,
                StoreDate = String.Format("{0:dd-MM-yyyy}", invoice.StoreDate),
                PaidCashAmount = invoice.PaidCashAmount,
                StoreId = invoice.StoreId,
                TotalDiscount = invoice.TotalDiscount,
                TotalQuantity = invoice.TotalQuantity,
                TotalVat = invoice.TotalVat,
                UserId = invoice.UserId
            };
            model.Items = new List<InvoiceItemModel>();
            foreach (var item in InvoiceDetailItems)
            {
                model.Items.Add(item.ToInvoiceItemModel());
            }
            return model;
        }

    }
}
