using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POS_Desktop.Models;
using static POS_Desktop.PurchaseInvoicePage;

namespace Smart_POS.ViewModel
{
    class PurchaseInvoiceViewModel : INotifyPropertyChanged
    {
        public PurchaseInvoiceViewModel()
        {
            _InvoiceDetailItems = new ObservableCollection<InvoiceDetailItem> { };
            ProductList = new ObservableCollection<Item> { };
            ProductUnitList = new List<Item> { };

            purchaseInvoice = new PurchaseInvoice();
            purchaseInvoice.ResetPaidCallback += new PurchaseInvoice.ResetPaidCallbackEventHandler(resetPaid);
            purchaseInvoice.DiscountCallback += new PurchaseInvoice.DiscountCallbackEventHandler(calcDiscount);
            purchaseInvoice.ResetPaidCashCallback += new PurchaseInvoice.ResetPaidCashCallbackEventHandler(resetCashBankPaid);

            
            CurrentRow = 0;
        }
        public void ProductSelected()
        {
            InvoiceDetailItems[CurrentRow].Load_ProductUnits();
            GetProductPrice();
            InvoiceDetailItems[CurrentRow].CalcSummaryCallback += new InvoiceDetailItem.CalcSummaryCallbackEventHandler(calcSummary);
        }
        public void GetProductPrice()
        {
            using var client = new HttpClient();

            var requestUri = new Uri($"http://localhost:8000/ords/accounting/utils/get_product_price?p_company_id=0&p_product_id={HttpUtility.UrlEncode(InvoiceDetailItems[CurrentRow].ProductId.ToString())}", UriKind.Absolute);

            var response = client.GetAsync(requestUri).Result;
            var res = JsonConvert.DeserializeObject<ProductPrice>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                InvoiceDetailItems[CurrentRow].ProductBarcode = res.Barcode;
                InvoiceDetailItems[CurrentRow].Quantity = res.Quantity;
                InvoiceDetailItems[CurrentRow].ProductUnitId = res.DefaultUnitId;
                InvoiceDetailItems[CurrentRow].Price = res.BasePrice;
                InvoiceDetailItems[CurrentRow].TotalPrice = res.TotalPrice;
                InvoiceDetailItems[CurrentRow].DiscountPercentage = res.Discount;
                InvoiceDetailItems[CurrentRow].DiscountValue = res.DiscountValue;
                InvoiceDetailItems[CurrentRow].PostDiscountPrice = res.PostDiscountTotalPrice;
                InvoiceDetailItems[CurrentRow].VatPercentage = res.VatPercentage;
                InvoiceDetailItems[CurrentRow].VatValue = res.VatValue;
                InvoiceDetailItems[CurrentRow].PreDiscountVatValue = res.PreDiscountVatValue;
                InvoiceDetailItems[CurrentRow].TotalAmount = res.TotalAmount;

                //purchaseInvoice.ClientDiscount = 0;
                calcSummary();
            }
        }

        public void ChangePrice()
        {
            //InvoiceDetailItems[CurrentRow].Price = (InvoiceDetailItems[CurrentRow].ChangeTotalAmount * 100 / (100 + InvoiceDetailItems[CurrentRow].VatPercentage) / float.Parse(InvoiceDetailItems[CurrentRow].Quantity)).ToString();
            //RecalcPrice();
        }
        public void RecalcPrice()
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
        public void calcSummary()
        {
            purchaseInvoice.PreDiscountTotalAmount = 0;
            purchaseInvoice.TotalDiscount = 0;
            purchaseInvoice.PostDiscountTotalAmount = 0;
            purchaseInvoice.TotalVat = 0;
            purchaseInvoice.PreDiscountTotalVat = 0;
            purchaseInvoice.TotalQuantity = 0;
            purchaseInvoice.InvoiceTotalAmount = 0;
            foreach (var item in InvoiceDetailItems)
            {
                purchaseInvoice.PreDiscountTotalAmount += double.Parse(item.TotalPrice);
                purchaseInvoice.TotalDiscount += double.Parse(item.DiscountValue);
                purchaseInvoice.PostDiscountTotalAmount += double.Parse(item.PostDiscountPrice);
                purchaseInvoice.TotalVat += double.Parse(item.VatValue);
                purchaseInvoice.PreDiscountTotalVat += double.Parse(item.PreDiscountVatValue);
                purchaseInvoice.TotalQuantity += int.Parse(item.Quantity);
                purchaseInvoice.InvoiceTotalAmount += double.Parse(item.TotalAmount);

            }
            purchaseInvoice.PreDiscountTotalAmount = Math.Round(purchaseInvoice.PreDiscountTotalAmount, 6);
            purchaseInvoice.TotalDiscount = Math.Round(purchaseInvoice.TotalDiscount, 6);
            purchaseInvoice.PostDiscountTotalAmount = Math.Round(purchaseInvoice.PostDiscountTotalAmount, 6);
            purchaseInvoice.TotalVat = Math.Round(purchaseInvoice.TotalVat, 6);
            purchaseInvoice.PreDiscountTotalVat = Math.Round(purchaseInvoice.PreDiscountTotalVat, 6);
            purchaseInvoice.InvoiceTotalAmount = Math.Round(purchaseInvoice.InvoiceTotalAmount, 6);
            resetPaid();
        }
        public void calcDiscount(float DiscountPercent)
        {
            for (int i = 0; i < InvoiceDetailItems.Count; i++)
            {
                InvoiceDetailItems[i].DiscountPercentage = DiscountPercent;
                InvoiceDetailItems[i].DiscountValue = (float.Parse(InvoiceDetailItems[i].TotalPrice) * InvoiceDetailItems[i].DiscountPercentage / 100).ToString();
                InvoiceDetailItems[i].PostDiscountPrice = (float.Parse(InvoiceDetailItems[i].TotalPrice) - float.Parse(InvoiceDetailItems[i].DiscountValue)).ToString(); ;
                InvoiceDetailItems[i].VatValue = (float.Parse(InvoiceDetailItems[i].PostDiscountPrice) * InvoiceDetailItems[i].VatPercentage / 100).ToString();
                InvoiceDetailItems[i].TotalAmount = Math.Round((float.Parse(InvoiceDetailItems[i].PostDiscountPrice) + float.Parse(InvoiceDetailItems[i].VatValue)), 2).ToString();
            }
            calcSummary();
        }
        public void resetPaid()
        {
            purchaseInvoice.PaidAmount = purchaseInvoice.InvoiceTotalAmount;
            purchaseInvoice.DeferredAmount = 0;

            resetCashBankPaid();
        }
        public void resetCashBankPaid()
        {
            purchaseInvoice.PaidCashAmount = purchaseInvoice.PaidAmount;
            purchaseInvoice.PaidBankAmount = 0;
        }
        public int CurrentRow { get; set; }
        private PurchaseInvoice purchaseInvoice;
        //public List<Item> ProductList { get; set; }

        private ObservableCollection<Item> _productList;


        public ObservableCollection<Item> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged("ProductList");
            }
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
            set
            {
                _InvoiceDetailItems = value;
                OnPropertyChanged("InvoiceDetailItems");
            }
        }

    }
}
