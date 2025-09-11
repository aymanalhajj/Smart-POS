using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using Smart_POS.Models;
using System.Windows;
using Smart_POS.Repository;
using System.Diagnostics;

namespace Smart_POS.ViewModels
{
    public class AccVoucherItemViewModel : INotifyPropertyChanged
    {
        public delegate void CalcSummaryCallbackEventHandler();
        public event CalcSummaryCallbackEventHandler CalcSummaryCallback;
        public delegate void GetProductUnitPriceCallbackEventHandler();
        public event GetProductUnitPriceCallbackEventHandler GetProductUnitPriceCallback;
        public void Load_ProductUnits()
        {
            //ProductUnitList = ApiRepository.getInstance().GetProductUnitList(ProductId.ToString());
        }
        public AccVoucherItemViewModel()
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
        public string? AccVoucherDtlId { get; set; }
        public string? _account_id { get; set; }
        public string? _ref_id;
        public string? _amount;
        public string? _note;
        public string? _cost_cntr_id { get; set; }
        public string? _tax_rate;
        public string? _tax_amount;
        public string? _total_amount;
        public float? _change_total_amount;

        public string? AccountId
        {
            get
            {
                return _account_id;
            }
            set
            {
                _account_id = value;
                OnPropertyChanged("AccountId");
            }
        }
        public string RefId
        {
            get
            {
                return _ref_id;
            }
            set
            {
                _ref_id = value;
                OnPropertyChanged("RefId");
            }
        }
        public string Amount
        {
            get
            {
                if (_amount == null)
                {
                    _amount = "0";
                }
                return _amount;
            }
            set
            {
                float q;
                if (value == null || value.Equals("") || value.Equals("0") || float.TryParse(value, out q) == false)
                {
                    _amount = "0";
                }
                else
                {
                    _amount = value;
                }
                OnPropertyChanged("Amount");
            }
        }
        public string? Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                OnPropertyChanged("Note");
            }
        }
        public string CostCntrId
        {
            get
            {
                return _cost_cntr_id;
            }
            set
            {
                _cost_cntr_id = value;
                OnPropertyChanged("CostCntrId");
            }
        }
        public string TaxRate
        {
            get
            {
                if (_tax_rate == null)
                {
                    _tax_rate = "0";
                }
                return _tax_rate;
            }
            set
            {
                float q;
                if (value == null || value.Equals("") || value.Equals("0") || float.TryParse(value, out q) == false)
                {
                    _tax_rate = "0";
                }
                else
                {
                    _tax_rate = value;
                }
                OnPropertyChanged("TaxRate");
            }
        }
        public string TaxAmount
        {
            get
            {
                if (_tax_rate == null)
                {
                    _tax_amount = "0";
                }
                return _tax_amount;
            }
            set
            {
                _tax_amount = value;
                OnPropertyChanged("TaxAmount");
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
                    //Amount = (float.Parse(value.ToString()) * 100 / (100 + float.Parse(VatPercentage)) / int.Parse(Quantity)).ToString();
                    RecalcPrice();
                    if (CalcSummaryCallback != null)
                    {
                        CalcSummaryCallback();
                    }
                }
                OnPropertyChanged("ChangeTotalAmount");
            }
        }
        public void ResetProductPrice(AccVoucherItemModel model)
        {
            try
            {
                AccVoucherDtlId = model.AccVoucherDtlId;
                AccountId = model.AccountId;
                RefId = model.RefId;
                Amount = model.Amount.ToString();
                Note = model.Note;
                CostCntrId = model.CostCntrId;
                TaxRate = model.TaxRate.ToString();
                TaxAmount = model.TaxAmount.ToString();
                TotalAmount = model.TotalAmount.ToString();
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
                if (Amount != null && Amount != "")
                {
                    TaxAmount = ((float.Parse(TaxRate) * float.Parse(Amount)) / 100).ToString();
                    TotalAmount = Math.Round((float.Parse(TaxAmount) + float.Parse(Amount)), 2).ToString();
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

        public AccVoucherItemModel ToInvoiceItemModel()
        {
            AccVoucherItemModel model = new()
            {
                AccVoucherDtlId = this.AccVoucherDtlId,
                AccountId = this.AccountId,
                RefId = this.RefId,
                Amount = float.Parse(this.Amount),
                Note = this.Note,
                CostCntrId = this.CostCntrId,
                TaxRate = float.Parse(this.TaxRate),
                TaxAmount = float.Parse(this.TaxAmount),
                TotalAmount = this.TotalAmount
            };
            return model;
        }
        static public AccVoucherItemViewModel FromInvoiceItemModel(AccVoucherItemModel model)
        {
            AccVoucherItemViewModel viewModel = new()
            {
                AccVoucherDtlId = model.AccVoucherDtlId,
                AccountId = model.AccountId,
                RefId = model.RefId,
                Amount = model.Amount.ToString(),
                Note = model.Note,
                CostCntrId = model.CostCntrId,
                TaxRate = model.TaxRate.ToString(),
                TaxAmount = model.TaxAmount.ToString(),
                TotalAmount = model.TotalAmount.ToString()
            };
            return viewModel;
        }
    }
}
