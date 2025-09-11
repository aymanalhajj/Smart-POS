using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class AccVoucherViewModel : INotifyPropertyChanged
    {
        public AccVoucherViewModel()
        {
            _InvoiceDetailItems = new ObservableCollection<AccVoucherItemViewModel> { };
            _InvoiceListItems = new ObservableCollection<AccVoucherListItemModel> { };
            ProductList = new ObservableCollection<Item> { };

            BranchList = new ObservableCollection<Item> { };
            CostCenterList = new ObservableCollection<Item> { };
            StoreList = new ObservableCollection<Item> { };

            AccountList = new ObservableCollection<Item> { };
            BankList = new ObservableCollection<Item> { };
            ProviderList = new ObservableCollection<Item> { };

            Filters = new AcVoucherViewModel();
            Invoice = new AcVoucherViewModel();

            //Invoice.ResetPaidCallback += new AcVoucherViewModel.ResetPaidCallbackEventHandler(ResetPaid);
            //invoice.DiscountCallback += new AcVoucherViewModel.DiscountCallbackEventHandler(DistributeDiscount);
            //invoice.ResetPaidCashCallback += new AcVoucherViewModel.ResetPaidCashCallbackEventHandler(ResetCashBankPaid);

            CurrentRow = 0;
            InvoiceToEditIndex = 0;
            repo = new AccVoucherRepo();

            InitLists();
        }
        public delegate bool ValidateCallbackEventHandler();
        public event ValidateCallbackEventHandler ValidateCallback;
        private AccVoucherRepo repo { get; set; }
        public int CurrentRow { get; set; }
        public int InvoiceToEditIndex { get; set; }
        private AcVoucherViewModel Invoice;
        private AcVoucherViewModel Filters;
        private ObservableCollection<AccVoucherItemViewModel> _InvoiceDetailItems;
        private ObservableCollection<AccVoucherListItemModel> _InvoiceListItems;

        private ObservableCollection<Item> _productList;
        private ObservableCollection<Item> _branchList;
        private ObservableCollection<Item> _storeList;
        private ObservableCollection<Item> _accountList;
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
                    ClearForm();
                }
                MessageBox.Show(res.Message);
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
                if (Invoice.AccVoucherId != 0)
                {
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "1", prev: "0", invoiceId: Invoice.AccVoucherId.ToString());
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
                if (Invoice.AccVoucherId != 0)
                {
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "0", prev: "1", invoiceId: Invoice.AccVoucherId.ToString());
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
            StoreList = repo.GetStoreList();
            CostCenterList = repo.GetCostCenterList();
            AccountList = repo.GetAccountList();
            //ProviderList = repo.GetProviderList();
            //BankList = repo.GetBankList();
            ProductList = repo.GetProductList();
        }
        private void ClearForm()
        {
            try
            {
                Invoice.clear();
                InvoiceDetailItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowInvoice(AccVoucherModel? model)
        {
            if (model != null && model.Items != null)
            {
                Invoice.FromInvoiceModel(model);
                InvoiceDetailItems.Clear();

                foreach (var item in model.Items)
                {
                    var itemViewModel = AccVoucherItemViewModel.FromInvoiceItemModel(item);
                    itemViewModel.CalcSummaryCallback += new AccVoucherItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                    //itemViewModel.GetProductUnitPriceCallback += new AccVoucherItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

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
                    var res = repo.GetPurchaseInvoice(first: "0", last: "0", next: "0", prev: "0", invoiceId: InvoiceListItems[InvoiceToEditIndex].AccVoucherId.ToString());
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
                InvoiceDetailItems[CurrentRow].CalcSummaryCallback -= new AccVoucherItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                //InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback -= new AccVoucherItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                InvoiceDetailItems[CurrentRow].CalcSummaryCallback += new AccVoucherItemViewModel.CalcSummaryCallbackEventHandler(CalcSummary);
                //InvoiceDetailItems[CurrentRow].GetProductUnitPriceCallback += new AccVoucherItemViewModel.GetProductUnitPriceCallbackEventHandler(GetProductUnitPrice);

                //var res = repo.GetProductPrice(InvoiceDetailItems[CurrentRow].ProductId.ToString());
                //if (res != null)
                //{
                //    InvoiceDetailItems[CurrentRow].ProductUnitId = res.ProductUnitId;
                //    InvoiceDetailItems[CurrentRow].ProductBarcode = res.ProductBarcode;
                //    InvoiceDetailItems[CurrentRow].Quantity = res.Quantity.ToString();
                //    InvoiceDetailItems[CurrentRow].ResetProductPrice(res);
                //    CalcSummary();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RecalcPrice()
        {
            try
            {
                if (InvoiceDetailItems[CurrentRow].Amount != null && InvoiceDetailItems[CurrentRow].Amount != "")
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
            Invoice.TotalDebtor = 0;
            Invoice.TotalCreditor = 0;
            Invoice.TotalVat = 0;

            foreach(var item in InvoiceListItems)
            {
                Invoice.TotalDebtor += (double)item.Amount;
            }
            foreach (var item in InvoiceDetailItems)
            {
                Invoice.TotalCreditor += double.Parse(item.TotalAmount);
                Invoice.TotalVat += double.Parse(item.TaxAmount);
            }
            Invoice.TotalDebtor = Math.Round(Invoice.TotalDebtor, 6);
            Invoice.TotalCreditor = Math.Round(Invoice.TotalCreditor, 6);
            Invoice.TotalVat = Math.Round(Invoice.TotalVat, 6);
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
        public AccVoucherModel ToInvoiceModel()
        {
            AccVoucherModel model = Invoice.ToInvoiceModel();
            foreach (var item in InvoiceDetailItems)
            {
                model.Items.Add(item.ToInvoiceItemModel());
            }
            return model;
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
        public ObservableCollection<Item> AccountList
        {
            get { return _accountList; }
            set
            {
                _accountList = value;
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
        //public AcVoucherViewModel _invoice;
        //public AcVoucherViewModel Invoice
        //{
        //    get { return _invoice; }
        //    set
        //    {
        //        _invoice = value;
        //        OnPropertyChanged("Invoice");
        //    }
        //}
        //public AcVoucherViewModel _filters;
        //public AcVoucherViewModel Filters
        //{
        //    get { return _filters; }
        //    set { _filters = value; }
        //}
        public ObservableCollection<AccVoucherItemViewModel> InvoiceDetailItems
        {
            get { return _InvoiceDetailItems; }
            set
            {
                _InvoiceDetailItems = value;
                OnPropertyChanged("InvoiceDetailItems");
            }
        }
        public ObservableCollection<AccVoucherListItemModel> InvoiceListItems
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
