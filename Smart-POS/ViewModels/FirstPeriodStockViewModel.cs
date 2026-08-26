using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    class FirstPeriodStockViewModel : INotifyPropertyChanged
    {

        public FirstPeriodStockViewModel()
        {
            _InvoiceDetailItems = new ObservableCollection<InvoiceItemViewModel> { };
            _InvoiceListItems = new ObservableCollection<FirstPeriodStockListItemModel> { };
            ProductList = new ObservableCollection<Item> { };

            BranchList = new ObservableCollection<Item> { };
            StoreList = new ObservableCollection<Item> { };
            SaveList = new ObservableCollection<Item> { };
            BankList = new ObservableCollection<Item> { };
            CostCenterList = new ObservableCollection<Item> { };
            ProviderList = new ObservableCollection<Item> { };

            filters = new InvoiceViewModel();
            invoice = new InvoiceViewModel();

            invoice.ResetPaidCallback += new InvoiceViewModel.ResetPaidCallbackEventHandler(ResetPaid);
            invoice.DiscountCallback += new InvoiceViewModel.DiscountCallbackEventHandler(DistributeDiscount);
            invoice.ResetPaidCashCallback += new InvoiceViewModel.ResetPaidCashCallbackEventHandler(ResetCashBankPaid);

            CurrentRow = 0;
            InvoiceToEditIndex = 0;
            repo = new FirstPeriodStockRepo();

            InitLists();
        }

        public delegate bool ValidateCallbackEventHandler();
        public event ValidateCallbackEventHandler ValidateCallback;
        private FirstPeriodStockRepo repo { get; set; }
        public int CurrentRow { get; set; }
        public int InvoiceToEditIndex { get; set; }
        private InvoiceViewModel invoice;
        private InvoiceViewModel filters;
        private ObservableCollection<InvoiceItemViewModel> _InvoiceDetailItems;
        private ObservableCollection<FirstPeriodStockListItemModel> _InvoiceListItems;



        private ObservableCollection<Item> _productList;
        private ObservableCollection<Item> _branchList;
        private ObservableCollection<Item> _storeList;
        private ObservableCollection<Item> _saveList;
        private ObservableCollection<Item> _bankList;
        private ObservableCollection<Item> _costCenterList;
        private ObservableCollection<Item> _providerList;

        public ICommand _SaveCommand;
        public ICommand _SearchCommand;
        public ICommand _NewCommand;
        public ICommand _FirstCommand;
        public ICommand _NextCommand;
        public ICommand _PrevCommand;
        public ICommand _LastCommand;

        private void SaveBtnClick()
        {
            if (!ValidateCallback())
                return;
            try
            {
                var res = repo.PostPurchaseInoice(ToInvoiceModel());
                if (res != null && res.Status == 1)
                {
                    MessageBox.Show(res.Message);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FirstBtnClick()
        {
            try
            {
                var res = repo.GetPurchaseInvoice(first: "1", last: "0", next: "0", prev: "0", invoiceId: "");
                ShowInvoice(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NextBtnClick()
        {
            try
            {
                if (Invoice.InvoiceId != 0)
                {
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "1", prev: "0", invoiceId: Invoice.InvoiceId.ToString());
                    ShowInvoice(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrevBtnClick()
        {
            try
            {
                if (Invoice.InvoiceId != 0)
                {
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "0", prev: "1", invoiceId: Invoice.InvoiceId.ToString());
                    ShowInvoice(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LastBtnClick()
        {
            try
            {
                var res = repo.GetPurchaseInvoice(first: "0", last: "1", next: "0", prev: "0", invoiceId: "");
                ShowInvoice(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchBtnClick()
        {
            try
            {
                InvoiceListItems = repo.GetAllPurchaseInoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InitLists()
        {
            BranchList = repo.GetBranchList();
            ProviderList = repo.GetProviderList();
            CostCenterList = repo.GetCostCenterList();
            SaveList = repo.GetSaveList();
            StoreList = repo.GetStoreList();
            BankList = repo.GetBankList();
            ProductList = repo.GetProductList();
        }
        private void ClearForm()
        {
            try
            {
                invoice.clear();
                InvoiceDetailItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowInvoice(FirstPeriodStockModel? model)
        {
            if (model != null && model.Items != null)
            {
                invoice.InvoiceId = model.InvoiceId;
                invoice.InvoiceNo = model.InvoiceNo ?? 0;
                invoice.InvoiceDate = model.InvoiceDate;
                invoice.StoreDate = model.StoreDate;
                invoice.ProviderInvDate = model.ProviderInvDate;
                invoice.StoreId = model.StoreId;
                invoice.InvoiceType = model.InvoiceType ?? 1;
                invoice.SafeId = model.SafeId;
                invoice.CostCenterId = model.CostCtrId;
                invoice.ProviderId = model.ProviderId;
                invoice.ProviderInvId = model.ProviderInvId;
                invoice.TotalQuantity = (int)(model.TotalQuantity ?? 0);
                invoice.InvoiceTotalAmount = (double)(model.InvoiceTotalAmount ?? 0);
                invoice.Notes = model.Notes;
                invoice.CompanyId = model.CompanyId ?? 1;
                invoice.UserId = model.UserId ?? 0;
                invoice.BranchId = model.BranchId;

                InvoiceDetailItems.Clear();

                foreach (var item in model.Items)
                {
                    var itemViewModel = new InvoiceItemViewModel
                    {
                        DtlId = item.DtlId,
                        ProductId = item.ProductId?.ToString(),
                        ProductUnitId = item.ProductUnitId?.ToString(),
                        Quantity = item.Quantity?.ToString(),
                        Price = item.Price?.ToString(),
                        TotalAmount = item.TotalAmount?.ToString()
                    };
                    itemViewModel.CalcSummaryCallback += new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                    itemViewModel.GetProductUnitPriceCallback += new InvoiceItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                    InvoiceDetailItems.Add(itemViewModel);
                }
            }
        }
        public void LoadInvoiceData()
        {
            try
            {
                if (InvoiceToEditIndex != -1)
                {
                    CurrentRow = -1;
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "0", prev: "0", invoiceId: InvoiceListItems[InvoiceToEditIndex].InvoiceId.ToString());
                    ShowInvoice(res);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetProductPrice()
        {
            try
            {

                InvoiceDetailItems[CurrentRow].Load_ProductUnits();
                InvoiceDetailItems[CurrentRow].CalcSummaryCallback -= new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback -= new InvoiceItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                InvoiceDetailItems[CurrentRow].CalcSummaryCallback += new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback += new InvoiceItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                var res = repo.GetProductPrice(InvoiceDetailItems[CurrentRow].ProductId.ToString());
                if (res != null)
                {
                    InvoiceDetailItems[CurrentRow].ProductUnitId = res.UnitId?.ToString();
                    InvoiceDetailItems[CurrentRow].ProductBarcode = res.Barcode;
                    InvoiceDetailItems[CurrentRow].Quantity = res.Quantity.ToString();
                    InvoiceDetailItems[CurrentRow].ResetProductPrice(res);
                    CalcSummary();
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
                var res = repo.GetProductPriceByBarcode(productBarcode);
                if (res != null)
                {
                    InvoiceDetailItems[CurrentRow].ProductId = res.ProductId?.ToString();
                    InvoiceDetailItems[CurrentRow].Quantity = res.Quantity.ToString();

                    InvoiceDetailItems[CurrentRow].ResetProductPrice(res);
                    InvoiceDetailItems[CurrentRow].Load_ProductUnits();
                    InvoiceDetailItems[CurrentRow].ProductUnitId = res.UnitId?.ToString();
                    InvoiceDetailItems[CurrentRow].CalcSummaryCallback -= new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                    InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback -= new InvoiceItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                    InvoiceDetailItems[CurrentRow].CalcSummaryCallback += new InvoiceItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                    InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback += new InvoiceItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);
                    CalcSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetProductUnitPrice()
        {
            try
            {
                if (CurrentRow != -1)
                {
                    var res = repo.GetProductUnitPrice(InvoiceDetailItems[CurrentRow].ProductId.ToString(), InvoiceDetailItems[CurrentRow].Quantity.ToString(), InvoiceDetailItems[CurrentRow].ProductUnitId.ToString());
                    if (res != null)
                    {
                        InvoiceDetailItems[CurrentRow].ResetProductPrice(res);
                        CalcSummary();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DistributeDiscount(float DiscountPercent)
        {
            for (int i = 0; i < InvoiceDetailItems.Count; i++)
            {
                InvoiceDetailItems[i].DiscountPercentage = DiscountPercent.ToString();
                InvoiceDetailItems[i].RecalcPrice();
            }
            CalcSummary();
        }
        public void RecalcPrice()
        {
            try
            {
                if (InvoiceDetailItems[CurrentRow].ProductId != null && InvoiceDetailItems[CurrentRow].ProductId != "")
                {
                    InvoiceDetailItems[CurrentRow].RecalcPrice();
                    CalcSummary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CalcSummary()
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
            ResetPaid();
        }
        public void ResetPaid()
        {
            invoice.PaidAmount = invoice.InvoiceTotalAmount;
            invoice.DeferredAmount = 0;

            ResetCashBankPaid();
        }
        public void ResetCashBankPaid()
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
        public FirstPeriodStockModel ToInvoiceModel()
        {
            FirstPeriodStockModel model = new()
            {
                InvoiceId = invoice.InvoiceId,
                InvoiceNo = invoice.InvoiceNo,
                InvoiceDate = ParseDate(invoice.InvoiceDate),
                StoreDate = ParseDate(invoice.StoreDate),
                ProviderInvDate = ParseDate(invoice.ProviderInvDate),
                StoreId = ToNullableInt(invoice.StoreId),
                InvoiceType = invoice.InvoiceType,
                SafeId = ToNullableInt(invoice.SafeId),
                CostCtrId = ToNullableInt(invoice.CostCenterId),
                ProviderId = ToNullableInt(invoice.ProviderId),
                ProviderInvId = invoice.ProviderInvId?.ToString(),
                TotalQuantity = invoice.TotalQuantity,
                InvoiceTotalAmount = (decimal)invoice.InvoiceTotalAmount,
                Notes = invoice.Notes?.ToString(),
                CompanyId = invoice.CompanyId,
                UserId = invoice.UserId,
                BranchId = ToNullableInt(invoice.BranchId),
                Items = new List<FirstPeriodStockItemModel>()
            };
            foreach (var item in InvoiceDetailItems)
            {
                model.Items.Add(new FirstPeriodStockItemModel
                {
                    DtlId = item.DtlId ?? 0,
                    ProductId = int.TryParse(item.ProductId, out var productId) ? productId : (int?)null,
                    ProductUnitId = int.TryParse(item.ProductUnitId, out var productUnitId) ? productUnitId : (int?)null,
                    Quantity = decimal.TryParse(item.Quantity, out var quantity) ? quantity : (decimal?)null,
                    Price = decimal.TryParse(item.Price, out var price) ? price : (decimal?)null,
                    TotalAmount = decimal.TryParse(item.TotalAmount, out var totalAmount) ? totalAmount : (decimal?)null
                });
            }
            return model;
        }

        private static DateTime? ParseDate(object value)
        {
            if (value == null) return null;
            if (value is DateTime dt) return dt;
            return DateTime.TryParse(value.ToString(), out var parsed) ? parsed : (DateTime?)null;
        }

        private static int? ToNullableInt(object value)
        {
            if (value == null) return null;
            return int.TryParse(value.ToString(), out var parsed) ? parsed : (int?)null;
        }

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
                OnPropertyChanged("AccountList");
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

        public InvoiceViewModel Filters
        {
            get { return filters; }
            set { filters = value; }
        }

        public ObservableCollection<InvoiceItemViewModel> InvoiceDetailItems
        {
            get { return _InvoiceDetailItems; }
            set
            {
                _InvoiceDetailItems = value;
                OnPropertyChanged("InvoiceDetailItems");
            }
        }
        public ObservableCollection<FirstPeriodStockListItemModel> InvoiceListItems
        {
            get { return _InvoiceListItems; }
            set
            {
                _InvoiceListItems = value;
                OnPropertyChanged("InvoiceListItems");
            }
        }
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
        public ICommand NewCommand
        {
            get
            {
                if (_NewCommand == null)
                {
                    _NewCommand = new RelayCommand(o => ClearForm());
                }
                return _NewCommand;
            }
        }
        public ICommand FirstCommand
        {
            get
            {
                if (_FirstCommand == null)
                {
                    _FirstCommand = new RelayCommand(o => FirstBtnClick());
                }
                return _FirstCommand;
            }
        }
        public ICommand NextCommand
        {
            get
            {
                if (_NextCommand == null)
                {
                    _NextCommand = new RelayCommand(o => NextBtnClick());
                }
                return _NextCommand;
            }
        }
        public ICommand PrevCommand
        {
            get
            {
                if (_PrevCommand == null)
                {
                    _PrevCommand = new RelayCommand(o => PrevBtnClick());
                }
                return _PrevCommand;
            }
        }
        public ICommand LastCommand
        {
            get
            {
                if (_LastCommand == null)
                {
                    _LastCommand = new RelayCommand(o => LastBtnClick());
                }
                return _LastCommand;
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(o => SearchBtnClick());
                }
                return _SearchCommand;
            }
        }

    }
}
