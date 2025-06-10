using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Smart_POS.Models;
using Smart_POS.Repository;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace Smart_POS.ViewModels
{
    internal class SetupTaxGroupViewModel : INotifyPropertyChanged
    {
        public SetupTaxGroupViewModel()
        {
            repo = new SetupTaxGroupRepo();
            Tax = new SetupTaxGroupItemViewModel();
            InitLists();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        public delegate bool ValidateCallbackEventHandler();
        public event ValidateCallbackEventHandler ValidateCallback;
        private SetupTaxGroupRepo repo { get; set; }
        public int CurrentRow { get; set; }
        public int InvoiceToEditIndex { get; set; }
        private SetupTaxGroupItemViewModel tax;
        private ObservableCollection<SetupTaxGroupListItemModel> _ListItems;
        public ObservableCollection<SetupTaxGroupListItemModel> ListItems
        {
            get
            {
                return _ListItems;
            }
            set
            {
                _ListItems = value;
                OnPropertyChanged("ListItems");
            }
        }
        public SetupTaxGroupItemViewModel _tax;
        public SetupTaxGroupItemViewModel Tax
        {
            get
            {
                return _tax;
            }
            set
            {
                _tax = value;
                OnPropertyChanged("Tax");
            }
        }
        private SetupTaxGroupItemViewModel filters;
        public void InitLists()
        {
            //AccountList = repo.GetAccountList();
        }
        private void ClearForm()
        {
            try
            {
                Tax.clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowData(SetupTaxGroupModel? model)
        {
            if (model != null)
            {
                Tax.FromModel(model);
            }
        }
        public void LoadData()
        {
            try
            {
                if (InvoiceToEditIndex != -1)
                {
                    CurrentRow = -1;
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "0", Id: ListItems[InvoiceToEditIndex].GroupId.ToString());
                    ShowData(res);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand _SaveCommand;
        public ICommand _SearchCommand;
        public ICommand _NewCommand;
        public ICommand _FirstCommand;
        public ICommand _NextCommand;
        public ICommand _PrevCommand;
        public ICommand _LastCommand;

        private void SaveBtnClick()
        {
            if (!ValidateCallback())
                return;
            try
            {
                var res = repo.Post(Tax.ToModel());
                if (res != null && res.Status == 1)
                {
                    MessageBox.Show(res.Message);
                    ClearForm();
                }
                else
                {
                    Utils.ShowMessage(res.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FirstBtnClick()
        {
            try
            {
                var res = repo.Get(first: "1", last: "0", next: "0", prev: "0", Id: "");
                ShowData(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NextBtnClick()
        {
            try
            {
                if (Tax.GroupId != null && !Tax.GroupId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "1", prev: "0", Id: Tax.GroupId.ToString());
                    ShowData(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrevBtnClick()
        {
            try
            {
                if (Tax.GroupId != null && !Tax.GroupId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "1", Id: Tax.GroupId.ToString());
                    ShowData(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LastBtnClick()
        {
            try
            {
                var res = repo.Get(first: "0", last: "1", next: "0", prev: "0", Id: "");
                ShowData(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchBtnClick()
        {
            try
            {
                ListItems = repo.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(o => SaveBtnClick());
                }
                return _SaveCommand;
            }
        }
        public ICommand NewCommand
        {
            get
            {
                if (_NewCommand == null)
                {
                    _NewCommand = new RelayCommand(o => ClearForm());
                }
                return _NewCommand;
            }
        }
        public ICommand FirstCommand
        {
            get
            {
                if (_FirstCommand == null)
                {
                    _FirstCommand = new RelayCommand(o => FirstBtnClick());
                }
                return _FirstCommand;
            }
        }
        public ICommand NextCommand
        {
            get
            {
                if (_NextCommand == null)
                {
                    _NextCommand = new RelayCommand(o => NextBtnClick());
                }
                return _NextCommand;
            }
        }
        public ICommand PrevCommand
        {
            get
            {
                if (_PrevCommand == null)
                {
                    _PrevCommand = new RelayCommand(o => PrevBtnClick());
                }
                return _PrevCommand;
            }
        }
        public ICommand LastCommand
        {
            get
            {
                if (_LastCommand == null)
                {
                    _LastCommand = new RelayCommand(o => LastBtnClick());
                }
                return _LastCommand;
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(o => SearchBtnClick());
                }
                return _SearchCommand;
            }
        }
    }
}

