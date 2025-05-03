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
    public class SalesProductBarcodesItemViewModel : INotifyPropertyChanged
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

        internal ProviderModel ToModel()
        {
            ProviderModel model = new()
            {

                AccountId = this.AccountId,
                BuildingNo  = BuildingNo.ToString(),
                CityId = this.CityId,
                CompanyId = this.CompanyId,
                CountryId = this.CountryId,
                Email = this.Email,
                Fax = this.Fax.ToString(),
                MobileNo= this.MobileNo.ToString(),
                NameAr = this.NameAr.ToString(),
                NameEn = this.NameEn.ToString(),
                Note = this.Note.ToString(),
                PostCode = this.PostCode.ToString(),
                ProviderId =this.ProviderId,
                RegionId = this.RegionId,
                Sreet = this.Sreet.ToString(),
                Status = this.Status,
                TaxNo = this.TaxNo.ToString(),
                TelNo = this.TelNo.ToString()

            };
            return model;
        }

        internal void clear()
        {
            AccountId = null;
            BuildingNo = null;
            CityId = null;
            CompanyId = null;
            CountryId = null;
            Email = null;
            Fax = null;
            MobileNo = null;
            NameAr = null;
            NameEn = null;
            Note = null;
            PostCode = null;
            ProviderId = null;
            RegionId = null;
            Sreet = null;
            Status = 0;
            TaxNo = null;
            TelNo = null;
        }

        internal void FromModel(ProviderModel model)
        {
            AccountId = model.AccountId;
            BuildingNo = model.BuildingNo;
            CompanyId = model.CompanyId;
            CountryId = model.CountryId;
            CityId = model.CityId;
            RegionId = model.RegionId;
            Email = model.Email;
            Fax = model.Fax;
            MobileNo = model.MobileNo;
            NameAr = model.NameAr;
            NameEn = model.NameEn;
            Note = model.Note;
            PostCode = model.PostCode;
            ProviderId = model.ProviderId;
            Sreet = model.Sreet;
            Status = model.Status;
            TaxNo = model.TaxNo;
            TelNo = model.TelNo;
        }
        #endregion
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
                OnPropertyChanged("TelNo");
            }
        }

        public object _fax { get; set; }
        public object Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                _fax = value;
                OnPropertyChanged("Fax");
            }
        }

        public string _email { get; set; }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public object _tax_no { get; set; }
        public object TaxNo
        {
            get
            {
                return _tax_no;
            }
            set
            {
                _tax_no = value;
                OnPropertyChanged("TaxNo");
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

        public object _building_no { get; set; }
        public object BuildingNo
        {
            get
            {
                return _building_no;
            }
            set
            {
                _building_no = value;
                OnPropertyChanged("BuildingNo");
            }
        }

        public object _sreet { get; set; }
        public object Sreet
        {
            get
            {
                return _sreet;
            }
            set
            {
                _sreet = value;
                OnPropertyChanged("Sreet");
            }
        }

        public object _post_code { get; set; }
        public object PostCode
        {
            get
            {
                return _post_code;
            }
            set
            {
                _post_code = value;
                OnPropertyChanged("PostCode");
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
    }
}