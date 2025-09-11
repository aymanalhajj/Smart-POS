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
    public class SetupProdGroupItemViewModel : INotifyPropertyChanged
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
        internal SetupProdGroupModel ToModel()
        {
            SetupProdGroupModel model = new()
            {
                GroupId = this.GroupId,
                NameAr = this.NameAr.ToString(),
                NameEn = this.NameEn.ToString(),
                Status = this.Status.ToString(),
                CompanyId = this.CompanyId,
            };
            return model;
        }
        internal void clear()
        {
            GroupId = null;
            NameAr = null;
            NameEn = null;
            Status = null;
            CompanyId = null;
        }
        internal void FromModel(SetupProdGroupModel model)
        {
            GroupId = model.GroupId;
            NameAr = model.NameAr;
            NameEn = model.NameEn;
            Status = model.Status;
            CompanyId = model.CompanyId;
        }
        #endregion
        public object _group_id { get; set; }
        public object GroupId
        {
            get
            {
                return _group_id;
            }
            set
            {
                _group_id = value;
                OnPropertyChanged("GroupId");
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