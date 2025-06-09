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
    public class SalesProductBarcodesItemViewModel : INotifyPropertyChanged
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

        internal SalesProductBarcodesModel ToModel()
        {
            SalesProductBarcodesModel model = new()
            {
                ProductBarcodeId = this.ProductBarcodeId,
                ProductId  = ProductId.ToString(),
                Barcode = this.Barcode,
                CompanyId = this.CompanyId,
            };
            return model;
        }

        internal void clear()
        {
            ProductBarcodeId = null;
            ProductId = null;
            Barcode = null;
            CompanyId = null;
        }

        internal void FromModel(SalesProductBarcodesModel model)
        {
            ProductBarcodeId = model.ProductBarcodeId;
            ProductId = model.ProductId;
            Barcode = model.Barcode;
            CompanyId = model.CompanyId;
        }
        #endregion
        public object _product_barcode_id { get; set; }
        public object ProductBarcodeId
        {
            get
            {
                return _product_barcode_id;
            }
            set
            {
                _product_barcode_id = value;
                OnPropertyChanged("ProductBarcodeId");
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