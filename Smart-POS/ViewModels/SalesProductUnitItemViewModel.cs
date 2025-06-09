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
    public class SalesProductUnitItemViewModel : INotifyPropertyChanged
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
        internal SalesProductUnitModel ToModel()
        {
            SalesProductUnitModel model = new()
            {
                ProductUnitId = this.ProductUnitId,
                ProductId  = ProductId.ToString(),
                UnitId = this.UnitId.ToString(),
                UnitValue = this.UnitValue.ToString(),
                PurchasePrice = this.PurchasePrice,
                SellPrice = this.SellPrice,
                Barcode = this.Barcode.ToString(),
                CompanyId= this.CompanyId
            };
            return model;
        }
        internal void clear()
        {
            ProductUnitId = null;
            ProductId = null;
            UnitId = null;
            UnitValue = null;
            PurchasePrice = null;
            SellPrice = null;
            Barcode = null;
            CompanyId = null;
        }
        internal void FromModel(SalesProductUnitModel model)
        {
            ProductUnitId = model.ProductUnitId;
            ProductId = model.ProductId;
            UnitId = model.UnitId;
            UnitValue = model.UnitValue;
            PurchasePrice = model.PurchasePrice;
            SellPrice = model.SellPrice;
            Barcode = model.Barcode;
            CompanyId = model.CompanyId;
        }
        #endregion
        public object _product_unit_id { get; set; }
        public object ProductUnitId
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
        public object _unit_id { get; set; }
        public object UnitId
        {
            get
            {
                return _unit_id;
            }
            set
            {
                _unit_id = value;
                OnPropertyChanged("UnitId");
            }
        }
        public object _unit_value { get; set; }
        public object UnitValue
        {
            get
            {
                return _unit_value;
            }
            set
            {
                _unit_value = value;
                OnPropertyChanged("UnitValue");
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
        public string _barcode { get; set; }
        public string Barcode
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
    }
}
