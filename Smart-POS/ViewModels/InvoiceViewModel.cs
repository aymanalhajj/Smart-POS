using System.ComponentModel;
using Smart_POS.Models;

namespace Smart_POS.ViewModels
{
    public class InvoiceViewModel : INotifyPropertyChanged
    {
        public delegate void ResetPaidCallbackEventHandler();
        public event ResetPaidCallbackEventHandler ResetPaidCallback;

        public delegate void ResetPaidCashCallbackEventHandler();
        public event ResetPaidCashCallbackEventHandler ResetPaidCashCallback;

        public delegate void DiscountCallbackEventHandler(float DiscountPercent);

        public event DiscountCallbackEventHandler DiscountCallback;
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
        // Wraps the new DTO's CostCtrId field. Kept named CostCenterId here since
        // XAML bindings (Invoice.CostCenterId / Filters.CostCenterId) already use
        // this name across all six invoice pages.
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

        // Converts the object-typed ComboBox SelectedValue-backed properties above
        // (ProviderId, ClientId, BranchId, StoreId, CostCenterId, SafeId, BankAccId)
        // into the nullable ints the new InvoiceDto declares.
        private static int? ToNullableInt(object value)
        {
            if (value == null)
                return null;
            if (value is int i)
                return i;
            if (int.TryParse(value.ToString(), out var parsed))
                return parsed;
            return null;
        }

        public void FromInvoiceModel(InvoiceModel model)
        {
            if (model != null)
            {
                BankAccId = model.BankAccId;
                BranchId = model.BranchId;
                ClientDiscount = (float)(model.ClientDiscount ?? 0);
                CompanyId = model.CompanyId ?? 0;
                CostCenterId = model.CostCtrId;
                DeferredAmount = (double)(model.DeferredAmount ?? 0);
                InvoiceNo = model.InvoiceNo ?? 0;
                InvoiceId = model.InvoiceId;
                InvoiceDate = model.InvoiceDate;
                InvoiceTotalAmount = (double)(model.InvoiceTotalAmount ?? 0);
                InvoiceType = model.InvoiceType ?? 0;
                Notes = model.Notes;
                PaidAmount = (double)(model.PaidAmount ?? 0);
                PaidBankAmount = (double)(model.PaidBankAmount ?? 0);
                PaidCashAmount = (double)(model.PaidCashAmount ?? 0);
                PaymentType = model.PaymentType ?? 0;
                PostDiscountTotalAmount = (double)(model.PostDiscountTotalAmount ?? 0);
                PreDiscountTotalAmount = (double)(model.PreTaxTotalAmount ?? 0);
                PreDiscountTotalVat = (double)(model.PreDiscountTotalVat ?? 0);
                ProviderId = model.ProviderId;
                ClientId = model.ClientId;
                ProviderInvDate = model.ProviderInvDate;
                ProviderInvId = model.ProviderInvId;
                SafeId = model.SafeId;
                StoreDate = model.StoreDate;
                StoreId = model.StoreId;
                TotalDiscount = (double)(model.TotalDiscount ?? 0);
                TotalQuantity = (int)(model.TotalQuantity ?? 0);
                TotalVat = (double)(model.TotalVat ?? 0);
                UserId = model.UserId ?? 0;

            }
            else
            {
                this.clear();
            }

        }

        public InvoiceModel ToInvoiceModel()
        {
            InvoiceModel model = new()
            {
                BankAccId = ToNullableInt(this.BankAccId),
                BranchId = ToNullableInt(this.BranchId),
                ClientDiscount = (decimal)this.ClientDiscount,
                CompanyId = this.CompanyId,
                CostCtrId = ToNullableInt(this.CostCenterId),
                DeferredAmount = (decimal)this.DeferredAmount,
                InvoiceDate = String.Format("{0:dd-MM-yyyy}", this.InvoiceDate),
                InvoiceId = this.InvoiceId,
                InvoiceNo = this.InvoiceNo,
                InvoiceTotalAmount = (decimal)this.InvoiceTotalAmount,
                InvoiceType = this.InvoiceType,
                Notes = this.Notes?.ToString(),
                PaidAmount = (decimal)this.PaidAmount,
                PaidBankAmount = (decimal)this.PaidBankAmount,
                PaymentType = this.PaymentType,
                PostDiscountTotalAmount = (decimal)this.PostDiscountTotalAmount,
                PreTaxTotalAmount = (decimal)this.PreDiscountTotalAmount,
                PreDiscountTotalVat = (decimal)this.PreDiscountTotalVat,
                ProviderId = ToNullableInt(this.ProviderId),
                ClientId = ToNullableInt(this.ClientId),
                ProviderInvDate = String.Format("{0:dd-MM-yyyy}", this.ProviderInvDate),
                ProviderInvId = this.ProviderInvId?.ToString(),
                SafeId = ToNullableInt(this.SafeId),
                StoreDate = String.Format("{0:dd-MM-yyyy}", this.StoreDate),
                PaidCashAmount = (decimal)this.PaidCashAmount,
                StoreId = ToNullableInt(this.StoreId),
                TotalDiscount = (decimal)this.TotalDiscount,
                TotalQuantity = this.TotalQuantity,
                TotalVat = (decimal)this.TotalVat,
                UserId = this.UserId,
                Items = new List<InvoiceItemModel>()
            };
            return model;
        }
        public void clear()
        {
            BankAccId = null;
            BranchId = null;
            ClientDiscount = 0;
            CompanyId = 1;
            CostCenterId = null;
            DeferredAmount = 0;
            InvoiceNo = 0;
            InvoiceId = 0;
            InvoiceDate = DateTime.Now;
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
