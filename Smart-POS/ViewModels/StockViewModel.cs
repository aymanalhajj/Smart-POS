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
    public class StockViewModel : INotifyPropertyChanged
    {
        public delegate void ResetPaidCallbackEventHandler();
        public event ResetPaidCallbackEventHandler ResetPaidCallback;

        public delegate void ResetPaidCashCallbackEventHandler();
        public event ResetPaidCashCallbackEventHandler ResetPaidCashCallback;

        public delegate void DiscountCallbackEventHandler(float DiscountPercent);

        public event DiscountCallbackEventHandler DiscountCallback;
        public StockViewModel()
        {
            OrderDate = DateTime.Now;
            ProviderInvDate = DateTime.Now;
            StoreDate = DateTime.Now;
            items = new List<InvoiceItemViewModel> { new InvoiceItemViewModel() };
            PaymentType = 1;
            Accountable = 0;
            CompanyId = 1;

        }
        public int _order_id { get; set; }
        public int OrderId
        {
            get
            {
                return _order_id;
            }
            set
            {
                _order_id = value;
                OnPropertyChanged("OrderId");
            }
        }
        public int _order_no { get; set; }
        public int OrderNo
        {
            get
            {
                return _order_no;
            }
            set
            {
                _order_no = value;
                OnPropertyChanged("OrderNo");
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
        public object _order_date { get; set; }
        public object OrderDate
        {
            get
            {
                return _order_date;
            }
            set
            {
                _order_date = value;
                OnPropertyChanged("OrderDate");
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
        public object _ref_id { get; set; }
        public object RefId
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
        public int _accountable { get; set; }
        public int Accountable
        {
            get
            {
                return _accountable;
            }
            set
            {
                _accountable = value;
                OnPropertyChanged("Accountable");
            }
        }

        public object _account_id { get; set; }
        public object AccountId
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

        public object _client_id { get; set; }
        public object ClientId
        {
            get
            {
                return _client_id;
            }
            set
            {
                _client_id = value;
                OnPropertyChanged("ClientId");
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
        public void FromInvoiceModel(StockModel model)
        {
            if (model != null)
            {
                BranchId = model.BranchId;
                CompanyId = model.CompanyId;
                AccountId = model.AccountId;
                RefId = model.RefId;
                CostCenterId = model.CostCtrId;
                CostCenterId = model.CostCtrId;
                Accountable = model.Accountable;
                OrderNo = model.OrderNo;
                OrderId = model.OrderId;
                OrderDate = model.OrderDate;
                InvoiceTotalAmount = model.TotalAmount;
                Notes = model.Notes;
                StoreId = model.StoreId;
                InvoiceTotalAmount = model.TotalAmount;
                UserId = model.UserId;

            }
            else
            {
                this.clear();
            }

        }

        public StockModel ToInvoiceModel()
        {
            StockModel model = new()
            {
                OrderId = this.OrderId,
                OrderNo = this.OrderNo,
                OrderDate = String.Format("{0:dd-MM-yyyy}", this.OrderDate),
                BranchId = this.BranchId,
                RefId = this.RefId,
                TotalAmount = this.InvoiceTotalAmount,
                Notes = this.Notes,
                StoreId = this.StoreId,
                CostCtrId = this.CostCenterId,
                Accountable = this.Accountable,
                AccountId = this.AccountId,
                CompanyId = this.CompanyId,
                UserId = this.UserId,
                Items = new List<StockItemModel>()
            };
            return model;
        }
            public void clear()
        {
            BankAccId = null;
            AccountId = null;
            RefId = null;
            BranchId = null;
            Accountable = 0;
            ClientDiscount = 0;
            CompanyId = 1;
            CostCenterId = null;
            DeferredAmount = 0;
            OrderNo = 0;
            OrderId = 0;
            OrderDate = DateTime.Now;
            InvoiceTotalAmount = 0;
            InvoiceType = 1;
            Notes = null;
            PaidAmount = 0;
            PaidBankAmount = 0;
            PaidCashAmount = 0;
            PaymentType = 1;
            PostDiscountTotalAmount = 0;
            PreDiscountTotalAmount = 0;
            PreDiscountTotalVat = 0;
            ProviderId = null;
            ClientId = null;
            ProviderInvDate = DateTime.Now;
            ProviderInvId = null;
            SafeId = null;
            StoreDate = DateTime.Now;
            StoreId = null;
            TotalDiscount = 0;
            TotalQuantity = 0;
            TotalVat = 0;
            UserId = 0;

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
