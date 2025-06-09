using Newtonsoft.Json;
using Smart_POS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.ViewModels
{
    public class ProductItemViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal ProductModel ToModel()
        {
            ProductModel model = new()
            {

                ProductId = this.ProductId,
                ProductNameAr  = this.ProductNameAr.ToString(),
                ProductNameEn = this.ProductNameEn.ToString(),
                Barcode = this.Barcode.ToString(),
                TypeId = this.TypeId.ToString(),
                TaxGroupId = this.TaxGroupId.ToString(),
                TaxValue= this.TaxValue,
                DefaultUnitId = this.DefaultUnitId.ToString(),
                ProductGroupId = this.ProductGroupId,
                PurchasePrice = this.PurchasePrice,
                SellPrice = this.SellPrice,
                ProviderId =this.ProviderId.ToString(),
                ProductStatus = this.ProductStatus.ToString(),
                CompanyId = this.CompanyId,
                ProductNo = this.ProductNo.ToString()
            };
            return model;
        }

        internal void clear()
        {
            ProductId = null;
            ProductNameAr = null;
            ProductNameEn = null;
            Barcode = null;
            TypeId = null;
            TaxGroupId = null;
            TaxValue = null;
            DefaultUnitId = null;
            ProductGroupId = null;
            PurchasePrice = null;
            SellPrice = null;
            ProviderId = null;
            ProductStatus = null;
            CompanyId = null;
            ProductNo = null;
        }

        internal void FromModel(ProductModel model)
        {
            ProductId = model.ProductId;
            ProductNameAr = model.ProductNameAr;
            ProductNameEn = model.ProductNameEn;
            Barcode = model.Barcode;
            TypeId = model.TypeId;
            TaxGroupId = model.TaxGroupId;
            TaxValue = model.TaxValue;
            DefaultUnitId = model.DefaultUnitId;
            ProductGroupId = model.ProductGroupId;
            PurchasePrice = model.PurchasePrice;
            SellPrice = model.SellPrice;
            ProviderId = model.ProviderId;
            ProductStatus = model.ProductStatus;
            CompanyId = model.CompanyId;
            ProductNo = model.ProductNo;
        }
        #endregion
        public object _product_id { get; set; }
        public object ProductId
        {
            get
            {
                return _product_id;
            }
            set
            {
                _product_id = value;
                OnPropertyChanged("ProductId");
            }
        }
        public object _product_name_ar { get; set; }
        public object ProductNameAr
        {
            get
            {
                return _product_name_ar;
            }
            set
            {
                _product_name_ar = value;
                OnPropertyChanged("ProductNameAr");
            }
        }
        public object _product_name_en { get; set; }
        public object ProductNameEn
        {
            get
            {
                return _product_name_en;
            }
            set
            {
                _product_name_en = value;
                OnPropertyChanged("ProductNameEn");
            }
        }
        public object _barcode { get; set; }
        public object Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                OnPropertyChanged("Barcode");
            }
        }
        public object _type_id { get; set; }
        public object TypeId
        {
            get
            {
                return _type_id;
            }
            set
            {
                _type_id = value;
                OnPropertyChanged("TypeId");
            }
        }
        public object _tax_group_id { get; set; }
        public object TaxGroupId
        {
            get
            {
                return _tax_group_id;
            }
            set
            {
                _tax_group_id = value;
                OnPropertyChanged("TaxGroupId");
            }
        }
        public string _tax_value { get; set; }
        public string TaxValue
        {
            get
            {
                return _tax_value;
            }
            set
            {
                _tax_value = value;
                OnPropertyChanged("TaxValue");
            }
        }
        public object _default_unit_id { get; set; }
        public object DefaultUnitId
        {
            get
            {
                return _default_unit_id;
            }
            set
            {
                _default_unit_id = value;
                OnPropertyChanged("DefaultUnitId");
            }
        }
        public object _product_group_id { get; set; }
        public object ProductGroupId
        {
            get
            {
                return _product_group_id;
            }
            set
            {
                _product_group_id = value;
                OnPropertyChanged("ProductGroupId");
            }
        }
        public object _purchase_price { get; set; }
        public object PurchasePrice
        {
            get
            {
                return _purchase_price;
            }
            set
            {
                _purchase_price = value;
                OnPropertyChanged("PurchasePrice");
            }
        }
        public object _sell_price { get; set; }
        public object SellPrice
        {
            get
            {
                return _sell_price;
            }
            set
            {
                _sell_price = value;
                OnPropertyChanged("SellPrice");
            }
        }
        public object _provider_id { get; set; }
        public object ProviderId
        {
            get
            {
                return _provider_id;
            }
            set
            {
                _provider_id = value;
                OnPropertyChanged("ProviderId");
            }
        }
        public object _product_status { get; set; }
        public object ProductStatus
        {
            get
            {
                if (_product_status == null)
                    return 0;
                return _product_status;
            }
            set
            {
                _product_status = value;
                OnPropertyChanged("ProductStatus");
            }
        }
        public object _company_id { get; set; }
        public object CompanyId
        {
            get
            {
                return _company_id;
            }
            set
            {
                _company_id = value;
                OnPropertyChanged("CompanyId");
            }
        }

        public object _product_no { get; set; }
        public object ProductNo
        {
            get
            {
                return _product_no;
            }
            set
            {
                _product_no = value;
                OnPropertyChanged("ProductNo");
            }
        }
    }
}
