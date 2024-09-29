using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POS_Desktop.Models;
using static POS_Desktop.PurchaseInvoicePage;

namespace Smart_POS.ViewModel
{
    class PurchaseInvoiceViewModel
    {
        public PurchaseInvoiceViewModel()
        {
            _InvoiceDetailItems = new ObservableCollection<InvoiceDetailItem> { };
            ProductList = new List<Item> { };
            ProductUnitList = new List<Item> { };

            purchaseInvoice = new PurchaseInvoice();
            CurrentRow = 0;
        }
        public void ProductSelected()
        {
            InvoiceDetailItems[CurrentRow].ProductBarcode = "1000";
            InvoiceDetailItems[CurrentRow].Quantity = "1";
            InvoiceDetailItems[CurrentRow].ProductUnitId = 3;
            InvoiceDetailItems[CurrentRow].Price = "10";
            InvoiceDetailItems[CurrentRow].TotalPrice = "10";
            InvoiceDetailItems[CurrentRow].DiscountPercentage = "0";
            InvoiceDetailItems[CurrentRow].DiscountValue = "0";
            InvoiceDetailItems[CurrentRow].PostDiscountPrice = "10";
            InvoiceDetailItems[CurrentRow].VatPercentage = "15";
            InvoiceDetailItems[CurrentRow].VatValue = "1.5";
            InvoiceDetailItems[CurrentRow].TotalAmount = "6.5";


        }
        public int CurrentRow { get; set; }
        private PurchaseInvoice purchaseInvoice;
        public List<Item> ProductList { get; set; }
        public List<Item> ProductUnitList { get; set; }
        public PurchaseInvoice PurchaseInvoice
        {
            get { return purchaseInvoice; }
            set { purchaseInvoice = value; }
        }
        private ObservableCollection<InvoiceDetailItem> _InvoiceDetailItems;
        

        public ObservableCollection<InvoiceDetailItem> InvoiceDetailItems
        {
            get { return _InvoiceDetailItems; }
            set { _InvoiceDetailItems = value; }
        }

        private ICommand mUpdater;

        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                // Code implementation for execution
            }
        }
    }
}
