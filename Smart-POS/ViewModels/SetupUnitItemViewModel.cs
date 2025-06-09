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
    public class SetupUnitItemViewModel : INotifyPropertyChanged
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

        internal SetupUnitModel ToModel()
        {
            SetupUnitModel model = new()
            {
                UnitId = this.UnitId,
                UnitNameAr  = UnitNameAr.ToString(),
                CompanyId = this.CompanyId,
                UnitNameEn = this.UnitNameEn.ToString()
            };
            return model;
        }

        internal void clear()
        {
            UnitId = null;
            UnitNameAr = null;
            CompanyId = null;
            UnitNameEn = null;
        }

        internal void FromModel(SetupUnitModel model)
        {
            UnitId = model.UnitId;
            UnitNameAr = model.UnitNameAr;
            CompanyId = model.CompanyId;
            UnitNameEn = model.UnitNameEn;
        }
        #endregion
        public object _unit_id { get; set; }
        public object UnitId
        {
            get
            {
                return _unit_id;
            }
            set
            {
                _unit_id = value;
                OnPropertyChanged("UnitId");
            }
        }
        public object _unit_name_ar { get; set; }
        public object UnitNameAr
        {
            get
            {
                return _unit_name_ar;
            }
            set
            {
                _unit_name_ar = value;
                OnPropertyChanged("UnitNameAr");
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
        public object _unit_name_en { get; set; }
        public object UnitNameEn
        {
            get
            {
                return _unit_name_en;
            }
            set
            {
                _unit_name_en = value;
                OnPropertyChanged("UnitNameEn");
            }
        }
    }
}