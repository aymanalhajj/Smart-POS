using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
using Smart_POS.Models;

namespace Smart_POS.ViewModels
{
    internal class AcVoucherViewModel : INotifyPropertyChanged
    {
        public delegate void ResetPaidCallbackEventHandler();
        public event ResetPaidCallbackEventHandler ResetPaidCallback;

        public delegate void ResetPaidCashCallbackEventHandler();
        public event ResetPaidCashCallbackEventHandler ResetPaidCashCallback;

        public delegate void DiscountCallbackEventHandler(float DiscountPercent);

        public event DiscountCallbackEventHandler DiscountCallback;
        public AcVoucherViewModel()
        {
            VoucherDate = DateTime.Now;
            PaymentMethod = 1;
            //VoucherType = 2;
            CompanyId = 1;
        }
        public int _acc_voucher_id { get; set; }
        public int AccVoucherId
        {
            get
            {
                return _acc_voucher_id;
            }
            set
            {
                _acc_voucher_id = value;
                OnPropertyChanged("AccVoucherId");
            }
        }
        public int _amount { get; set; }
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
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
        public int _payment_method { get; set; }
        public int PaymentMethod
        {
            get
            {
                if (_payment_method == null)
                    return 1;
                return _payment_method;
            }
            set
            {
                _payment_method = value;
                if (ResetPaidCashCallback != null)
                {
                    ResetPaidCashCallback();
                }
                OnPropertyChanged("PaymentMethod");
            }
        }
        public object _paid_to { get; set; }
        public object PaidTo
        {
            get
            {
                return _paid_to;
            }
            set
            {
                _paid_to = value;
                OnPropertyChanged("PaidTo");
            }
        }
        public object _voucher_date { get; set; }
        public object VoucherDate
        {
            get
            {
                return _voucher_date;
            }
            set
            {
                _voucher_date = value;
                OnPropertyChanged("VoucherDate");
            }
        }
        public int _posted { get; set; }
        public int Posted
        {
            get
            {
                return _posted;
            }
            set
            {
                _posted = value;
                OnPropertyChanged("Posted");
            }
        }
        public int _voucher_type { get; set; }
        public int VoucherType
        {
            get
            {
                return _voucher_type;
            }
            set
            {
                _voucher_type = value;
                OnPropertyChanged("VoucherType");
            }
        }
        public object _note { get; set; }
        public object Note
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
        public int _check_no { get; set; }
        public int CheckNo
        {
            get
            {
                return _check_no;
            }
            set
            {
                _check_no = value;
                OnPropertyChanged("CheckNo");
            }
        }
        public object _check_date { get; set; }
        public object CheckDate
        {
            get
            {
                return _check_date;
            }
            set
            {
                _check_date = value;
                OnPropertyChanged("CheckDate");
            }
        }
        public object _cost_cntr_id { get; set; }
        public object CostCntrId
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
        public double _total_debtor { get; set; }
        public double TotalDebtor
        {
            get
            {
                return _total_debtor;
            }
            set
            {
                _total_debtor = value;
                OnPropertyChanged("TotalDebtor");
            }
        }
        public double _total_creditor { get; set; }
        public double TotalCreditor
        {
            get
            {
                return _total_creditor;
            }
            set
            {
                _total_creditor = value;
                OnPropertyChanged("TotalCreditor");
            }
        }
        public void FromInvoiceModel(AccVoucherModel model)
        {
            if (model != null)
            {
                AccVoucherId = model.AccVoucherId;
                Amount = model.Amount;
                AccountId = model.AccountId;
                RefId = model.RefId;
                PaymentMethod = model.PaymentMethod;
                PaidTo = model.PaidTo;
                VoucherDate = model.VoucherDate;
                Posted = model.Posted;
                VoucherType = model.VoucherType;
                Note = model.Note;
                CheckNo = model.CheckNo;
                CheckDate = model.CheckDate;
                CostCntrId = model.CostCntrId;
                CompanyId = model.CompanyId;
                TotalVat = model.TotalVat;
            }
            else
            {
                this.clear();
            }
        }
        public AccVoucherModel ToInvoiceModel()
        {
            AccVoucherModel model = new()
            {
                AccVoucherId = this.AccVoucherId,
                Amount = this.Amount,
                AccountId = this.AccountId,
                RefId = this.RefId,
                PaymentMethod = this.PaymentMethod,
                PaidTo = this.PaidTo,
                VoucherDate = String.Format("{0:dd-MM-yyyy}", this.VoucherDate),
                Posted = this.Posted,
                VoucherType = this.VoucherType,
                Note = this.Note,
                CheckNo = this.CheckNo,
                CheckDate = this.CheckDate,
                CostCntrId = this.CostCntrId,
                CompanyId = this.CompanyId,
                TotalVat = this.TotalVat,
                Items = new List<AccVoucherItemModel>()
            };
            return model;
        }
        public void clear()
        {
            AccVoucherId = 0;
            Amount = 0;
            AccountId = null;
            RefId = null;
            PaymentMethod = 1;
            PaidTo = 0;
            VoucherDate = DateTime.Now;
            Posted = 0;
            VoucherType = 2;
            Note = null;
            CheckNo = 0;
            CheckDate = DateTime.Now;
            CostCntrId = null;
            CompanyId = 1;
            TotalVat = 0;
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
