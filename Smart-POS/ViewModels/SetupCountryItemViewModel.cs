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
    public class SetupCountryItemViewModel : INotifyPropertyChanged
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

        internal SetupCountryModel ToModel()
        {
            SetupCountryModel model = new()
            {
                CountryId = this.CountryId,
                NameAr  = NameAr.ToString(),
                NameEn = this.NameEn.ToString(),
                NationalityNameAr = this.NationalityNameAr.ToString(),
                NationalityNameEn = this.NationalityNameEn.ToString(),
                Status = this.Status.ToString(),
                CompanyId = this.CompanyId
            };
            return model;
        }

        internal void clear()
        {
            CountryId = null;
            NameAr = null;
            NameEn = null;
            NationalityNameAr = null;
            NationalityNameEn = null;
            Status = null;
            CompanyId = null;
        }

        internal void FromModel(SetupCountryModel model)
        {
            CountryId = model.CountryId;
            NameAr = model.NameAr;
            NameEn = model.NameEn;
            NationalityNameAr = model.NationalityNameEn;
            NationalityNameEn = model.NationalityNameEn;
            Status = model.Status;
            CompanyId = model.CompanyId;
        }
        #endregion
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
        public object _name_ar { get; set; }
        public object NameAr
        {
            get
            {
                return _name_ar;
            }
            set
            {
                _name_ar = value;
                OnPropertyChanged("NameAr");
            }
        }
        public object _name_en { get; set; }
        public object NameEn
        {
            get
            {
                return _name_en;
            }
            set
            {
                _name_en = value;
                OnPropertyChanged("NameEn");
            }
        }
        public object _nationality_name_ar { get; set; }
        public object NationalityNameAr
        {
            get
            {
                return _nationality_name_ar;
            }
            set
            {
                _nationality_name_ar = value;
                OnPropertyChanged("NationalityNameAr");
            }
        }
        public object _nationality_name_en { get; set; }
        public object NationalityNameEn
        {
            get
            {
                return _nationality_name_en;
            }
            set
            {
                _nationality_name_en = value;
                OnPropertyChanged("NationalityNameEn");
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
    }
}
