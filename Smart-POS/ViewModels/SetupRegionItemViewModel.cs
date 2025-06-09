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
    public class SetupRegionItemViewModel : INotifyPropertyChanged
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

        internal SetupRegionModel ToModel()
        {
            SetupRegionModel model = new()
            {
                RegionId = this.RegionId,
                RegionNameAr  = RegionNameAr.ToString(),
                RegionNameEn = this.RegionNameEn.ToString(),
                CountryId = this.CountryId.ToString(),
                CityId = this.CityId.ToString(),
                Status = this.Status.ToString(),
                CompanyId = this.CompanyId
            };
            return model;
        }

        internal void clear()
        {
            RegionId = null;
            RegionNameAr = null;
            RegionNameEn = null;
            CountryId = null;
            CityId = null;
            Status = null;
            CompanyId = null;
        }

        internal void FromModel(SetupRegionModel model)
        {
            RegionId = model.RegionId;
            RegionNameAr = model.RegionNameAr;
            RegionNameEn = model.RegionNameEn;
            CountryId = model.CountryId;
            CityId = model.CityId;
            Status = model.Status;
            CompanyId = model.CompanyId;
        }
        #endregion
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
        public object _region_name_ar { get; set; }
        public object RegionNameAr
        {
            get
            {
                return _region_name_ar;
            }
            set
            {
                _region_name_ar = value;
                OnPropertyChanged("RegionNameAr");
            }
        }
        public object _region_name_en { get; set; }
        public object RegionNameEn
        {
            get
            {
                return _region_name_en;
            }
            set
            {
                _region_name_en = value;
                OnPropertyChanged("RegionNameEn");
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