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
    public class SetupBankItemViewModel : INotifyPropertyChanged
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

        internal SetupBankModel ToModel()
        {
            SetupBankModel model = new()
            {
                BankAccId = this.BankAccId,
                AccNameAr  = AccNameAr.ToString(),
                AccountId = this.AccountId.ToString(),
                TelNo = this.TelNo.ToString(),
                MobileNo = this.MobileNo.ToString(),
                CountryId = this.CountryId,
                CityId = this.CityId,
                RegionId = this.RegionId,
                Note = this.Note.ToString(),
                ForAllBranches = this.ForAllBranches.ToString(),
                Status = this.Status.ToString(),
                CompanyId = this.CompanyId,
                AccNameEn = this.AccNameEn.ToString()
            };
            return model;
        }

        internal void clear()
        {
            BankAccId = null;
            AccNameAr = null;
            AccountId = null;
            TelNo = null;
            MobileNo = null;
            CountryId = null;
            CityId = null;
            RegionId = null;
            Note = null;
            ForAllBranches = null;
            Status = null;
            CompanyId = null;
            AccNameEn = null;
        }

        internal void FromModel(SetupBankModel model)
        {
            BankAccId = model.BankAccId;
            AccNameAr = model.AccNameAr;
            AccountId = model.AccountId;
            TelNo = model.TelNo;
            MobileNo = model.MobileNo;
            CountryId = model.CountryId;
            CityId = model.CityId;
            RegionId = model.RegionId;
            Note = model.Note;
            ForAllBranches = model.ForAllBranches;
            Status = model.Status;
            CompanyId = model.CompanyId;
            AccNameEn = model.AccNameEn;
        }
        #endregion
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
        public object _acc_name_ar { get; set; }
        public object AccNameAr
        {
            get
            {
                return _acc_name_ar;
            }
            set
            {
                _acc_name_ar = value;
                OnPropertyChanged("NameAr");
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
        public object _tel_no { get; set; }
        public object TelNo
        {
            get
            {
                return _tel_no;
            }
            set
            {
                _tel_no = value;
                OnPropertyChanged("NameEn");
            }
        }
        public object _mobile_no { get; set; }
        public object MobileNo
        {
            get
            {
                return _mobile_no;
            }
            set
            {
                _mobile_no = value;
                OnPropertyChanged("MobileNo");
            }
        }
        public object _country_id { get; set; }
        public object CountryId
        {
            get
            {
                return _country_id;
            }
            set
            {
                _country_id = value;
                OnPropertyChanged("CountryId");
            }
        }
        public object _city_id { get; set; }
        public object CityId
        {
            get
            {
                return _city_id;
            }
            set
            {
                _city_id = value;
                OnPropertyChanged("CityId");
            }
        }
        public object _region_id { get; set; }
        public object RegionId
        {
            get
            {
                return _region_id;
            }
            set
            {
                _region_id = value;
                OnPropertyChanged("RegionId");
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
        public object _for_all_branches { get; set; }
        public object ForAllBranches
        {
            get
            {
                if (_for_all_branches == null)
                    return 0;
                return _for_all_branches;
            }
            set
            {
                _for_all_branches = value;
                OnPropertyChanged("TelNo");
            }
        }
        public object _status { get; set; }
        public object Status
        {
            get
            {
                if (_status == null)
                    return 0;
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
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
        public object _acc_name_en { get; set; }
        public object AccNameEn
        {
            get
            {
                return _acc_name_en;
            }
            set
            {
                _acc_name_en = value;
                OnPropertyChanged("BuildingNo");
            }
        }
    }
}
