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
    public class SetupBranchItemViewModel : INotifyPropertyChanged
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

        internal SetupBranchModel ToModel()
        {
            SetupBranchModel model = new()
            {
                BranchId = this.BranchId,
                NameAr  = NameAr.ToString(),
                NameEn = this.NameEn.ToString(),
                TelNo = this.TelNo.ToString(),
                MobileNo= this.MobileNo.ToString(),
                Fax = this.Fax.ToString(),
                Email = this.Email,
                ComercialRecNo = this.ComercialRecNo.ToString(),
                TaxNo = this.TaxNo.ToString(),
                CountryId = this.CountryId,
                CityId = this.CityId,
                RegionId = this.RegionId,
                BuildingNo = this.BuildingNo.ToString(),
                Sreet = this.Sreet.ToString(),
                PostCode = this.PostCode.ToString(),
                Note = this.Note.ToString(),
                CompanyId = this.CompanyId
            };
            return model;
        }

        internal void clear()
        {
            BranchId = null;
            NameAr = null;
            NameEn = null;
            TelNo = null;
            MobileNo = null;
            Fax = null;
            Email = null;
            ComercialRecNo = null;
            TaxNo = null;
            CountryId = null;
            CityId = null;
            RegionId = null;
            BuildingNo = null;
            Sreet = null;
            PostCode = null;
            Note = null;
            CompanyId = null;
        }

        internal void FromModel(SetupBranchModel model)
        {
            BranchId = model.BranchId;
            NameAr = model.NameAr;
            NameEn = model.NameEn;
            TelNo = model.TelNo;
            MobileNo = model.MobileNo;
            Fax = model.Fax;
            Email = model.Email;
            ComercialRecNo = model.ComercialRecNo;
            TaxNo = model.TaxNo;
            CountryId = model.CountryId;
            CityId = model.CityId;
            RegionId = model.RegionId;
            BuildingNo = model.BuildingNo;
            Sreet = model.Sreet;
            PostCode = model.PostCode;
            Note = model.Note;
            CompanyId = model.CompanyId;
        }
        #endregion
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
        public object _comercial_rec_no { get; set; }
        public object ComercialRecNo
        {
            get
            {
                return _comercial_rec_no;
            }
            set
            {
                _comercial_rec_no = value;
                OnPropertyChanged("ComercialRecNo");
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
