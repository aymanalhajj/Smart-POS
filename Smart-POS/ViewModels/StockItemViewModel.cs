using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using Smart_POS.Models;
using System.Windows;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class StockItemViewModel : INotifyPropertyChanged
    {
        public delegate void CalcSummaryCallbackEventHandler();
        public event CalcSummaryCallbackEventHandler CalcSummaryCallback;
        public delegate void GetProductUnitPriceCallbackEventHandler();
        public event GetProductUnitPriceCallbackEventHandler GetProductUnitPriceCallback;

        public void Load_ProductUnits()
        {
            ProductUnitList = ApiRepository.getInstance().GetProductUnitList(ProductId.ToString());
        }
        public StockItemViewModel()
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
        public string? _discount_percentage;
        public string? _discount_value;
        public string? _post_discount_price;


        public string? _vat_percentage;
        public string? _vat_value;
        public string? _total_amount;
        public float? _change_total_amount;

        public string _quantity;
        public string? Dtl_Id { get; set; }
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
        public string Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                int q;
                if (value == null || value.Equals("") || value.Equals("0") || int.TryParse(value, out q) == false)
                {
                    _quantity = "1";
                }
                else
                {
                    _quantity = value;
                }
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
                if (_product_unit_id != value && _product_unit_id != null)
                {
                    _product_unit_id = value;
                    if (GetProductUnitPriceCallback != null && _product_unit_id != null)
                    {
                        GetProductUnitPriceCallback();
                    }
                }
                else
                {
                    _product_unit_id = value;
                }

                OnPropertyChanged("ProductUnitId");
            }
        }
        public string? Price
        {
            get
            {
                return _price;
            }
            set
            {
                float q;
                if (value == null || value.Equals("") || value.Equals("0") || float.TryParse(value, out q) == false)
                {
                    _price = (float.Parse(OriginalPrice.ToString()) * 100 / (100 + float.Parse(VatPercentage) / int.Parse(Quantity))).ToString();
                }
                else
                {
                    _price = value;
                }
                OnPropertyChanged("Price");
            }
        }
        public string? TotalPrice
        {
            get
            {
                if (_total_price == null)
                {
                    _total_price = "0";
                }
                return _total_price;
            }
            set
            {
                _total_price = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public string? DiscountPercentage
        {
            get
            {
                if (_discount_percentage == null)
                {
                    _discount_percentage = "0";
                }
                return _discount_percentage;
            }
            set
            {
                float q;
                if (value == null || value.Equals("") || value.Equals("0") || float.TryParse(value, out q) == false)
                {
                    _discount_percentage = "0";
                }
                else
                {
                    _discount_percentage = value;
                }
                OnPropertyChanged("DiscountPercentage");
            }
        }
        public string? DiscountValue
        {
            get
            {
                if (_discount_value == null)
                {
                    _discount_value = "0";
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
                    _post_discount_price = "0";
                }
                return _post_discount_price;
            }
            set
            {
                _post_discount_price = value;
                OnPropertyChanged("PostDiscountPrice");
            }
        }
        public string? VatPercentage
        {
            get
            {
                if (_vat_percentage == null)
                {
                    _vat_percentage = "0";
                }
                return _vat_percentage;
            }
            set
            {
                float q;
                if (value == null || value.Equals("") || value.Equals("0") || float.TryParse(value, out q) == false)
                {
                    _vat_percentage = "0";
                }
                else
                {
                    _vat_percentage = value;
                }
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
                    _vat_value = "0";
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
                    _original_price = "0";
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
                    _total_amount = "0";
                }
                return _total_amount;
            }
            set
            {
                _total_amount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        public float? ChangeTotalAmount
        {
            get
            {
                return _change_total_amount;
            }
            set
            {
                if (value == null || value == 0 || value.Equals(""))
                {
                    _change_total_amount = null;
                }
                else
                {
                    _change_total_amount = value;
                }
                if (value != null && value != 0 && !value.Equals(""))
                {
                    DiscountPercentage = "0";
                    Price = (float.Parse(value.ToString()) * 100 / (100 + float.Parse(VatPercentage) / int.Parse(Quantity))).ToString();
                    RecalcPrice();                    
                    if (CalcSummaryCallback != null)
                    {
                        CalcSummaryCallback();
                    }
                }
                OnPropertyChanged("ChangeTotalAmount");
            }
        }

        public void ResetProductPrice(InvoiceItemModel model)
        {
            try
            {
                Price = model.Price.ToString();
                TotalPrice = model.TotalPrice;
                DiscountPercentage = model.DiscountPercentage.ToString();
                DiscountValue = model.DiscountValue;
                PostDiscountPrice = model.PostDiscountPrice;
                VatPercentage = model.VatPercentage.ToString();
                VatValue = model.VatValue;
                PreDiscountVatValue = model.PreDiscountVatValue;
                TotalAmount = model.TotalAmount;
                OriginalPrice = model.OriginalPrice;
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
                if (ProductId != null && ProductId != "")
                {
                    TotalPrice = (float.Parse(Price) * int.Parse(Quantity)).ToString();
                    PreDiscountVatValue = (float.Parse(TotalPrice) * float.Parse(VatPercentage) / 100).ToString();
                    DiscountValue = (float.Parse(TotalPrice) * float.Parse(DiscountPercentage) / 100).ToString();
                    PostDiscountPrice = (float.Parse(TotalPrice) - float.Parse(DiscountValue)).ToString(); ;
                    VatValue = (float.Parse(PostDiscountPrice) * float.Parse(VatPercentage) / 100).ToString();
                    TotalAmount = Math.Round((float.Parse(PostDiscountPrice) + float.Parse(VatValue)), 2).ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        public StockItemModel ToInvoiceItemModel()
        {
            StockItemModel model = new()
            {
                Dtl_Id = this.Dtl_Id,
                ProductBarcode = this.ProductBarcode,
                Price = float.Parse(this.Price),
                ProductId = this.ProductId,
                Quantity = int.Parse(this.Quantity),
                TotalAmount = this.TotalAmount,
                ProductUnitId = this.ProductUnitId
            };
            return model;
        }

        static public StockItemViewModel FromStockItemModel(StockItemModel model)
        {
            StockItemViewModel viewModel = new()
            {
                Dtl_Id = model.Dtl_Id,
                ProductBarcode = model.ProductBarcode,
                ProductId = model.ProductId,
                Quantity = model.Quantity.ToString(),
                Price = model.Price.ToString(),
                TotalAmount = model.TotalAmount
            };
            viewModel.Load_ProductUnits();
            viewModel.ProductUnitId = model.ProductUnitId;
            return viewModel;
        }
    }
}
