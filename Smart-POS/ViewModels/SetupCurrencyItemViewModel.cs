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
    public class SetupCurrencyItemViewModel : INotifyPropertyChanged
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

        internal SetupCurrencyModel ToModel()
        {
            SetupCurrencyModel model = new()
            {
                CurrencyId = this.CurrencyId,
                CodeAr  = CodeAr.ToString(),
                NameAr = this.NameAr.ToString(),
                CreatedBy = this.CreatedBy.ToString(),
                CreatedAt = this.CreatedAt,
                ModifiedBy = this.ModifiedBy,
                ModifiedAt = this.ModifiedAt,
                CompanyId= this.CompanyId,
                NameEn = this.NameEn.ToString(),
                CodeEn = this.CodeEn.ToString()
            };
            return model;
        }

        internal void clear()
        {
            CurrencyId = null;
            CodeAr = null;
            NameAr = null;
            CreatedBy = null;
            CreatedAt = null;
            ModifiedBy = null;
            ModifiedAt = null;
            CompanyId = null;
            NameEn = null;
            CodeEn = null;
        }

        internal void FromModel(SetupCurrencyModel model)
        {
            CurrencyId = model.CurrencyId;
            CodeAr = model.CodeAr;
            NameAr = model.NameAr;
            CreatedBy = model.CreatedBy;
            CreatedAt = model.CreatedAt;
            ModifiedBy = model.ModifiedBy;
            ModifiedAt = model.ModifiedAt;
            CompanyId = model.CompanyId;
            NameEn = model.NameEn;
            CodeEn = model.CodeEn;
        }
        #endregion
        public object _currency_id { get; set; }
        public object CurrencyId
        {
            get
            {
                return _currency_id;
            }
            set
            {
                _currency_id = value;
                OnPropertyChanged("CurrencyId");
            }
        }
        public object _code_ar { get; set; }
        public object CodeAr
        {
            get
            {
                return _code_ar;
            }
            set
            {
                _code_ar = value;
                OnPropertyChanged("CodeAr");
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
        public object _created_by { get; set; }
        public object CreatedBy
        {
            get
            {
                return _created_by;
            }
            set
            {
                _created_by = value;
                OnPropertyChanged("CreatedBy");
            }
        }
        public object _created_at { get; set; }
        public object CreatedAt
        {
            get
            {
                return _created_at;
            }
            set
            {
                _created_at = value;
                OnPropertyChanged("CreatedAt");
            }
        }
        public object _modified_by { get; set; }
        public object ModifiedBy
        {
            get
            {
                return _modified_by;
            }
            set
            {
                _modified_by = value;
                OnPropertyChanged("ModifiedBy");
            }
        }
        public object _modified_at { get; set; }
        public object ModifiedAt
        {
            get
            {
                return _modified_at;
            }
            set
            {
                _modified_at = value;
                OnPropertyChanged("ModifiedAt");
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
        public object _code_en { get; set; }
        public object CodeEn
        {
            get
            {
                return _code_en;
            }
            set
            {
                _code_en = value;
                OnPropertyChanged("CodeEn");
            }
        }
    }
}
