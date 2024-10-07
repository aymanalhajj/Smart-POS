using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using POS_Desktop.Models;
using Smart_POS.Models;

namespace Smart_POS.ViewModels
{
    public class InvoiceViewModel : INotifyPropertyChanged
    {

        private string _customError;
        public string CustomError
        {
            get => _customError;
            set
            {
                //ValidateInputData(value);
                _customError = value;
                OnPropertyChanged("CustomError");
            }
        }

        private string _customError2;
        public string CustomError2
        {
            get => _customError2;
            set
            {
                //ValidateInputData(value);
                _customError2 = value;
                OnPropertyChanged("CustomError2");
            }
        }

        public void ValidateInputData(string value)
        {
            if (value!= null && !string.Equals(value, "test", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Test is not valid.");
            }
        }

        public InvoiceViewModel()
        {
            InvoiceDate = DateTime.Now;
            ProviderInvDate = DateTime.Now;
            StoreDate = DateTime.Now;
            items = new List<InvoiceItemViewModel> { new InvoiceItemViewModel() };
            PaymentType = 1;
            InvoiceType = 1;
            CompanyId = 1;
        }
        public int _invoice_id { get; set; }
        public int InvoiceId
        {
            get
            {
                return _invoice_id;
            }
            set
            {
                _invoice_id = value;
                OnPropertyChanged("InvoiceId");
            }
        }
        public int _invoice_no { get; set; }
        public int InvoiceNo
        {
            get
            {
                return _invoice_no;
            }
            set
            {
                _invoice_no = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
        public object provider_inv_id;
        public object ProviderInvId
        {
            get
            {
                return provider_inv_id;
            }
            set
            {
                provider_inv_id = value;
                OnPropertyChanged("ProviderInvId");
            }
        }
        public object _notes { get; set; }
        public object Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }
        public object _invoice_date { get; set; }
        public object InvoiceDate
        {
            get
            {
                return _invoice_date;
            }
            set
            {
                _invoice_date = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
        public object _provider_inv_date { get; set; }
        public object ProviderInvDate
        {
            get
            {
                return _provider_inv_date;
            }
            set
            {
                _provider_inv_date = value;
                OnPropertyChanged("ProviderInvDate");
            }
        }
        public object _store_date { get; set; }
        public object StoreDate
        {
            get
            {
                return _store_date;
            }
            set
            {
                _store_date = value;
                OnPropertyChanged("StoreDate");
            }
        }

        public object _branch_id { get; set; }
        public object BranchId
        {
            get
            {
                return _branch_id;
            }
            set
            {
                _branch_id = value;
                OnPropertyChanged("BranchId");
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
        public object _cost_ctr_id { get; set; }
        public object CostCenterId
        {
            get
            {
                return _cost_ctr_id;
            }
            set
            {
                _cost_ctr_id = value;
                OnPropertyChanged("CostCenterId");
            }
        }

        public delegate void ResetPaidCallbackEventHandler();
        public event ResetPaidCallbackEventHandler ResetPaidCallback;

        public delegate void ResetPaidCashCallbackEventHandler();
        public event ResetPaidCashCallbackEventHandler ResetPaidCashCallback;

        public delegate void DiscountCallbackEventHandler(float DiscountPercent);

        public event DiscountCallbackEventHandler DiscountCallback;

        public int _invoice_type { get; set; }
        public int InvoiceType
        {
            get
            {
                return _invoice_type;
            }
            set
            {
                _invoice_type = value;
                if (ResetPaidCallback != null)
                {
                    ResetPaidCallback();
                }
                OnPropertyChanged("InvoiceType");
            }
        }
        public object _store_id { get; set; }
        public object StoreId
        {
            get
            {
                return _store_id;
            }
            set
            {
                _store_id = value;
                OnPropertyChanged("StoreId");
            }
        }
        public object safe_id { get; set; }
        public object SafeId
        {
            get
            {
                return safe_id;
            }
            set
            {
                safe_id = value;
                OnPropertyChanged("SafeId");
            }
        }
        public List<InvoiceItemViewModel> items { get; set; }

        public int _payment_type { get; set; }
        public int PaymentType
        {
            get
            {
                return _payment_type;
            }
            set
            {
                _payment_type = value;
                if (ResetPaidCashCallback != null)
                {
                    ResetPaidCashCallback();
                }
                OnPropertyChanged("PaymentType");
            }
        }
        public double _pre_discount_total_amount { get; set; }
        public double PreDiscountTotalAmount
        {
            get
            {
                return _pre_discount_total_amount;
            }
            set
            {
                _pre_discount_total_amount = value;
                OnPropertyChanged("PreDiscountTotalAmount");
            }
        }
        public double _pre_discount_total_vat { get; set; }
        public double PreDiscountTotalVat
        {
            get
            {
                return _pre_discount_total_vat;
            }
            set
            {
                _pre_discount_total_vat = value;
                OnPropertyChanged("PreDiscountTotalVat");
            }
        }
        public float _client_discount { get; set; }
        public float ClientDiscount
        {
            get
            {
                return _client_discount;
            }
            set
            {
                _client_discount = value;
                if (DiscountCallback != null)
                {
                    DiscountCallback((float)(_client_discount / (PreDiscountTotalVat + PreDiscountTotalAmount) * 100));
                }
                OnPropertyChanged("ClientDiscount");
            }
        }
        public double _total_discount { get; set; }
        public double TotalDiscount
        {
            get
            {
                return _total_discount;
            }
            set
            {
                _total_discount = value;
                OnPropertyChanged("TotalDiscount");
            }
        }
        public double _post_discount_total_amount { get; set; }
        public double PostDiscountTotalAmount
        {
            get
            {
                return _post_discount_total_amount;
            }
            set
            {
                _post_discount_total_amount = value;
                OnPropertyChanged("PostDiscountTotalAmount");
            }
        }
        public double _total_vat { get; set; }
        public double TotalVat
        {
            get
            {
                return _total_vat;
            }
            set
            {
                _total_vat = value;
                OnPropertyChanged("TotalVat");
            }
        }
        public int _total_quantity { get; set; }
        public int TotalQuantity
        {
            get
            {
                return _total_quantity;
            }
            set
            {
                _total_quantity = value;
                OnPropertyChanged("TotalQuantity");
            }
        }
        public double _invoice_total_amount { get; set; }
        public double InvoiceTotalAmount
        {
            get
            {
                return _invoice_total_amount;
            }
            set
            {
                _invoice_total_amount = value;
                OnPropertyChanged("InvoiceTotalAmount");
            }
        }
        public double _paid_cash_amount { get; set; }
        public double PaidCashAmount
        {
            get
            {
                return _paid_cash_amount;
            }
            set
            {
                if (PaidAmount - value < 0)
                {
                    _paid_cash_amount = PaidAmount;
                }
                else
                {
                    _paid_cash_amount = value;
                }
                OnPropertyChanged("PaidCashAmount");
                PaidBankAmount = PaidAmount - _paid_cash_amount;
            }
        }
        public double _paid_bank_amount { get; set; }
        public double PaidBankAmount
        {
            get
            {
                return _paid_bank_amount;
            }
            set
            {
                if (PaidAmount - value < 0)
                {
                    _paid_cash_amount = PaidAmount;
                }
                else
                {
                    _paid_bank_amount = value;
                }
                OnPropertyChanged("PaidBankAmount");
                _paid_cash_amount = PaidAmount - _paid_bank_amount;
                OnPropertyChanged("PaidCashAmount");
            }
        }
        public int _company_id { get; set; }
        public int CompanyId
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
        public int _user_id { get; set; }
        public int UserId
        {
            get
            {
                if (_user_id == 0)
                    return 1;
                return _user_id;
            }
            set
            {
                _user_id = value;
                OnPropertyChanged("UserId");
            }
        }
        public object _bank_acc_id { get; set; }
        public object BankAccId
        {
            get
            {
                return _bank_acc_id;
            }
            set
            {
                _bank_acc_id = value;
                OnPropertyChanged("BankAccId");
            }
        }
        public double _paid_amount { get; set; }
        public double PaidAmount
        {
            get
            {
                return _paid_amount;
            }
            set
            {
                if (InvoiceTotalAmount - value < 0)
                {
                    _paid_amount = InvoiceTotalAmount;
                }
                else
                {
                    _paid_amount = value;
                }
                OnPropertyChanged("PaidAmount");
                DeferredAmount = InvoiceTotalAmount - _paid_amount;
            }
        }
        public double _deferred_amount { get; set; }
        public double DeferredAmount
        {
            get
            {
                return _deferred_amount;
            }
            set
            {
                if (InvoiceTotalAmount - value < 0)
                {
                    _deferred_amount = InvoiceTotalAmount;
                }
                else
                {
                    _deferred_amount = value;
                }
                OnPropertyChanged("DeferredAmount");
                _paid_amount = InvoiceTotalAmount - _deferred_amount;
                OnPropertyChanged("PaidAmount");
            }
        }
        public void FromInvoiceModel(InvoiceModel model)
        {
            BankAccId = model.BankAccId;
            BranchId = model.BranchId;
            ClientDiscount = model.ClientDiscount;
            CompanyId = model.CompanyId;
            CostCenterId = model.CostCenterId;
            DeferredAmount = model.DeferredAmount;
            InvoiceNo = model.InvoiceNo;
            InvoiceId = model.InvoiceId;
            InvoiceDate = model.InvoiceDate;
            InvoiceTotalAmount = model.InvoiceTotalAmount;
            InvoiceType = model.InvoiceType;
            Notes = model.Notes;
            //PaidAmount = model.PaidAmount;
            PaidBankAmount = model.PaidBankAmount;
            PaidCashAmount = model.PaidCashAmount;
            PaymentType = model.PaymentType;
            PostDiscountTotalAmount = model.PostDiscountTotalAmount;
            PreDiscountTotalAmount = model.PreDiscountTotalAmount;
            PreDiscountTotalVat = model.PreDiscountTotalVat;
            ProviderId = model.ProviderId;
            ProviderInvDate = model.ProviderInvDate;
            ProviderInvId = model.ProviderInvId;
            SafeId = model.SafeId;
            StoreDate = model.StoreDate;
            StoreId = model.StoreId;
            TotalDiscount = model.TotalDiscount;
            TotalQuantity = model.TotalQuantity;
            TotalVat = model.TotalVat;
            UserId = model.UserId;
            
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
    }
}
