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
    public class SalesProductFilesItemViewModel : INotifyPropertyChanged
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
        internal SalesProductFilesModel ToModel()
        {
            SalesProductFilesModel model = new()
            {
                FileId = this.FileId,
                FilePath  = FilePath.ToString(),
                FileMimeType = this.FileMimeType.ToString(),
                FileSize = this.FileSize.ToString(),
                IsThumbnail = this.IsThumbnail,
                ProductId = this.ProductId
            };
            return model;
        }
        internal void clear()
        {
            FileId = null;
            FilePath = null;
            FileMimeType = null;
            FileSize = null;
            IsThumbnail = null;
            ProductId = null;
        }
        internal void FromModel(SalesProductFilesModel model)
        {
            FileId = model.FileId;
            FilePath = model.FilePath;
            FileMimeType = model.FileMimeType;
            FileSize = model.FileSize;
            IsThumbnail = model.IsThumbnail;
            ProductId = model.ProductId;
        }
        #endregion
        public object _file_id { get; set; }
        public object FileId
        {
            get
            {
                return _file_id;
            }
            set
            {
                _file_id = value;
                OnPropertyChanged("FileId");
            }
        }
        public object _file_path { get; set; }
        public object FilePath
        {
            get
            {
                return _file_path;
            }
            set
            {
                _file_path = value;
                OnPropertyChanged("FilePath");
            }
        }
        public object _file_mime_type { get; set; }
        public object FileMimeType
        {
            get
            {
                return _file_mime_type;
            }
            set
            {
                _file_mime_type = value;
                OnPropertyChanged("FileMimeType");
            }
        }
        public object _file_size { get; set; }
        public object FileSize
        {
            get
            {
                return _file_size;
            }
            set
            {
                _file_size = value;
                OnPropertyChanged("FileSize");
            }
        }
        public object _is_thumbnail { get; set; }
        public object IsThumbnail
        {
            get
            {
                return _is_thumbnail;
            }
            set
            {
                _is_thumbnail = value;
                OnPropertyChanged("IsThumbnail");
            }
        }
        public object _product_id { get; set; }
        public object ProductId
        {
            get
            {
                return _product_id;
            }
            set
            {
                _product_id = value;
                OnPropertyChanged("ProductId");
            }
        }
    }
}
