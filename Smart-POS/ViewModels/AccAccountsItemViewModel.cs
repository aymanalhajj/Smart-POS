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
    public class AccAccountsItemViewModel : INotifyPropertyChanged
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

        internal AccAccountsModel ToModel()
        {
            AccAccountsModel model = new()
            {
                AccountId = this.AccountId,
                AccountParent = this.AccountParent,
                AccountNameAr  = this.AccountNameAr.ToString(),
                AccountNameEn = this.AccountNameEn.ToString(),
                AccountType = this.AccountType,
                AccountNature = this.AccountNature,
                CompanyId = this.CompanyId,
                SubAccount = this.SubAccount.ToString(),
                AccountLevel = this.AccountLevel,
                AccDate= this.AccDate,
                
            };
            return model;
        }

        internal void clear()
        {
            AccountId = null;
            AccountParent = null;
            AccountNameAr = null;
            AccountNameEn = null;
            AccountType = null;
            AccountNature = null;
            CompanyId = null;
            SubAccount = null;
            AccountLevel = null;
            AccDate = null;
        }

        internal void FromModel(AccAccountsModel model)
        {
            AccountId = model.AccountId;
            AccountParent = model.AccountParent;
            AccountNameAr  = model.AccountNameAr;
            AccountNameEn = model.AccountNameEn;
            AccountType = model.AccountType;
            AccountNature = model.AccountNature;
            CompanyId = model.CompanyId;
            SubAccount = model.SubAccount;
            AccountLevel = model.AccountLevel;
            AccDate= model.AccDate;
        }
        #endregion
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
        public object _account_parent { get; set; }
        public object AccountParent
        {
            get
            {
                return _account_parent;
            }
            set
            {
                _account_parent = value;
                OnPropertyChanged("AccountParent");
            }
        }
        public object _account_name_ar { get; set; }
        public object AccountNameAr
        {
            get
            {
                return _account_name_ar;
            }
            set
            {
                _account_name_ar = value;
                OnPropertyChanged("AccountNameAr");
            }
        }
        public object _account_name_en { get; set; }
        public object AccountNameEn
        {
            get
            {
                return _account_name_en;
            }
            set
            {
                _account_name_en = value;
                OnPropertyChanged("AccountNameEn");
            }
        }
        public object _account_type { get; set; }
        public object AccountType
        {
            get
            {
                return _account_type;
            }
            set
            {
                _account_type = value;
                OnPropertyChanged("AccountType");
            }
        }
        public object _account_nature { get; set; }
        public object AccountNature
        {
            get
            {
                if (_account_nature == null)
                    return 1;
                return _account_nature;
            }
            set
            {
                _account_nature = value;
                OnPropertyChanged("AccountNature");
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
        public string _sub_account { get; set; }
        public string SubAccount
        {
            get
            {
                return _sub_account;
            }
            set
            {
                _sub_account = value;
                OnPropertyChanged("SubAccount");
            }
        }
        public object _account_level { get; set; }
        public object AccountLevel
        {
            get
            {
                return _account_level;
            }
            set
            {
                _account_level = value;
                OnPropertyChanged("AccountLevel");
            }
        }
        public object _acc_date { get; set; }
        public object AccDate
        {
            get
            {
                return _acc_date;
            }
            set
            {
                _acc_date = value;
                OnPropertyChanged("AccDate");
            }
        }
    }
}
