using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using POS_Desktop.Models;
using System.Web;
using Smart_POS.Models;

namespace Smart_POS.ViewModels
{
    public class InvoiceItemViewModel : INotifyPropertyChanged
    {

        public delegate void CalcSummaryCallbackEventHandler();
        public event CalcSummaryCallbackEventHandler CalcSummaryCallback;

        public void Load_ProductUnits()
        {
            using var client = new HttpClient();
            var requestUri = new Uri($"http://localhost:8000/ords/accounting/lists/product_unit_list?p_company_id=0&p_lang_id=2&p_product_id={HttpUtility.UrlEncode(ProductId.ToString())}", UriKind.Absolute);

            //MessageBox.Show(requestUri.ToString());
            var response = client.GetAsync(requestUri).Result;
            var res = JsonConvert.DeserializeObject<LOV>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                ProductUnitList.Clear();
                for (int i = 0; i < res.Items?.Count; i++)
                {
                    Item? item = res.Items[i];
                    ProductUnitList.Add(item);
                }
            }
        }
        public InvoiceItemViewModel()
        {
            ProductUnitList = new ObservableCollection<Item> { };
        }

        private ObservableCollection<Item> _productUnitList;


        public ObservableCollection<Item> ProductUnitList
        {
            get { return _productUnitList; }
            set
            {

                _productUnitList = value;

                OnPropertyChanged("ProductUnitList");
            }
        }


        public string _product_Id { get; set; }
        public string? _product_barcode;

        public string _product_unit_id;
        public string? _price;
        public string? _total_price;
        public float? _discount_percentage;
        public string? _discount_value;
        public string? _post_discount_price;


        public float? _vat_percentage;
        public string? _vat_value;
        public string? _total_amount;
        public object? _change_total_amount;

        public string? _quantity;
        public string ProductId
        {
            get
            {
                return _product_Id;
            }
            set
            {
                _product_Id = value;
                OnPropertyChanged("ProductId");
            }
        }
        public string? ProductBarcode
        {
            get
            {
                if (_product_barcode == null)
                {
                    _product_barcode = "";
                }
                return _product_barcode;
            }
            set
            {
                _product_barcode = value;
                OnPropertyChanged("ProductBarcode");
            }
        }
        public string? Quantity
        {
            get
            {
                if (_quantity == null)
                {
                    _quantity = "";
                }
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public string ProductUnitId
        {
            get
            {
                return _product_unit_id;
            }
            set
            {
                _product_unit_id = value;
                OnPropertyChanged("ProductUnitId");
            }
        }
        public string? Price
        {
            get
            {
                if (_price == null)
                {
                    _price = "";
                }
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string? TotalPrice
        {
            get
            {
                if (_total_price == null)
                {
                    _total_price = "";
                }
                return _total_price;
            }
            set
            {
                _total_price = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public float? DiscountPercentage
        {
            get
            {
                if (_discount_percentage == null)
                {
                    _discount_percentage = 0;
                }
                return _discount_percentage;
            }
            set
            {
                _discount_percentage = value;

                DiscountValue = (float.Parse(TotalPrice) * DiscountPercentage / 100).ToString();
                PostDiscountPrice = (float.Parse(TotalPrice) - float.Parse(DiscountValue)).ToString(); ;
                VatValue = (float.Parse(PostDiscountPrice) * VatPercentage / 100).ToString();
                TotalAmount = Math.Round((float.Parse(PostDiscountPrice) + float.Parse(VatValue)), 2).ToString();
                OnPropertyChanged("DiscountPercentage");
            }
        }
        public string? DiscountValue
        {
            get
            {
                if (_discount_value == null)
                {
                    _discount_value = "";
                }
                return _discount_value;
            }
            set
            {
                _discount_value = value;
                OnPropertyChanged("DiscountValue");
            }
        }
        public string? PostDiscountPrice
        {
            get
            {
                if (_post_discount_price == null)
                {
                    _post_discount_price = "";
                }
                return _post_discount_price;
            }
            set
            {
                _post_discount_price = value;
                OnPropertyChanged("PostDiscountPrice");
            }
        }
        public float? VatPercentage
        {
            get
            {
                if(_vat_percentage==null)
                {
                    _vat_percentage = 0;
                }
                return _vat_percentage;
            }
            set
            {
                _vat_percentage = value;
                OnPropertyChanged("VatPercentage");
            }
        }
        public string? _pre_discount_vat_value;
        public string? PreDiscountVatValue
        {
            get
            {
                if (_pre_discount_vat_value == null)
                {
                    _pre_discount_vat_value = "0";
                }
                return _pre_discount_vat_value;
            }
            set
            {
                _pre_discount_vat_value = value;
                OnPropertyChanged("PreDiscountVatValue");
            }
        }

        public string? VatValue
        {
            get
            {
                if (_vat_value == null)
                {
                    _vat_value = "";
                }
                return _vat_value;
            }
            set
            {
                _vat_value = value;
                OnPropertyChanged("VatValue");
            }
        }

        public string? _original_price { get; set; }
        public string? OriginalPrice
        {
            get
            {
                if (_original_price == null)
                {
                    _original_price = "";
                }
                return _original_price;
            }
            set
            {
                _original_price = value;
                OnPropertyChanged("OriginalPrice");
            }
        }

        public string? TotalAmount
        {
            get
            {
                if (_total_amount == null)
                {
                    _total_amount = "";
                }
                return _total_amount;
            }
            set
            {
                _total_amount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        public object? ChangeTotalAmount
        {
            get
            {
                return _change_total_amount;
            }
            set
            {
                _change_total_amount = value;
                if (value != null && !value.Equals("0") && !value.Equals(""))
                {
                    DiscountPercentage = 0;
                    Price = (float.Parse(value.ToString()) * 100 / (100 + VatPercentage) / float.Parse(Quantity)).ToString();
                    TotalPrice = (float.Parse(value.ToString()) * 100 / (100 + VatPercentage)).ToString();
                    PreDiscountVatValue = (float.Parse(TotalPrice) * VatPercentage / 100).ToString();
                    DiscountValue = (float.Parse(TotalPrice) * DiscountPercentage / 100).ToString();
                    PostDiscountPrice = (float.Parse(TotalPrice) - float.Parse(DiscountValue)).ToString(); ;
                    VatValue = (float.Parse(PostDiscountPrice) * VatPercentage / 100).ToString();
                    TotalAmount = Math.Round((float.Parse(PostDiscountPrice) + float.Parse(VatValue)), 2).ToString();
                    if (CalcSummaryCallback != null)
                    {
                        CalcSummaryCallback();
                    }
                }
                OnPropertyChanged("ChangeTotalAmount");
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

        public InvoiceItemModel ToInvoiceItemModel()
        {
            InvoiceItemModel model = new()
            {
                Barcode = this.ProductBarcode,
                BasePrice = this.Price,
                DiscountPercentage = this.DiscountPercentage,
                DiscountValue = this.DiscountValue,
                PostDiscountTotalPrice = this.PostDiscountPrice,
                ProductId = this.ProductId,
                Quantity = this.Quantity,
                TotalAmount = this.TotalAmount,
                TotalPrice = this.TotalPrice,
                UnitId = this.ProductUnitId,
                VatPercentage = this.VatPercentage,
                VatValue = this.VatValue
            };
            return model;
        }
    }
}
