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
    public class SetupCityItemViewModel : INotifyPropertyChanged
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
        internal SetupCityModel ToModel()
        {
            SetupCityModel model = new()
            {
                CityId = this.CityId,
                CityNameAr  = CityNameAr.ToString(),
                CityNameEn = this.CityNameEn.ToString(),
                CountryId = this.CountryId.ToString(),
                Status = this.Status.ToString(),
                CompanyId = this.CompanyId
            };
            return model;
        }
        internal void clear()
        {
            CityId = null;
            CityNameAr = null;
            CityNameEn = null;
            CountryId = null;
            Status = null;
            CompanyId = null;
        }
        internal void FromModel(SetupCityModel model)
        {
            CityId = model.CityId;
            CityNameAr = model.CityNameAr;
            CityNameEn = model.CityNameEn;
            CountryId = model.CountryId;
            Status = model.Status;
            CompanyId = model.CompanyId;
        }
        #endregion
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
        public object _city_name_ar { get; set; }
        public object CityNameAr
        {
            get
            {
                return _city_name_ar;
            }
            set
            {
                _city_name_ar = value;
                OnPropertyChanged("CityNameAr");
            }
        }
        public object _city_name_en { get; set; }
        public object CityNameEn
        {
            get
            {
                return _city_name_en;
            }
            set
            {
                _city_name_en = value;
                OnPropertyChanged("CityNameEn");
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
