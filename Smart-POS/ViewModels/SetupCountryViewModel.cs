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
using System.Diagnostics.Metrics;

namespace Smart_POS.ViewModels
{
    internal class SetupCountryViewModel : INotifyPropertyChanged
    {
        public SetupCountryViewModel()
        {
            repo = new SetupCountryRepo();
            Country = new SetupCountryItemViewModel();
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
        private SetupCountryRepo repo { get; set; }
        public int CurrentRow { get; set; }
        public int InvoiceToEditIndex { get; set; }
        private SetupCountryItemViewModel country;
        private ObservableCollection<Item> _accountList;
        private ObservableCollection<SetupCountryListItemModel> _ListItems;
        private ObservableCollection<Item> _countryList;
        private ObservableCollection<Item> _cityList;
        private ObservableCollection<Item> _regionList;
        public ObservableCollection<Item> CountryList
        {
            get
            {
                return _countryList;
            }
            set
            {
                _countryList = value;
                OnPropertyChanged("CountryList");
            }
        }
        public ObservableCollection<Item> CityList
        {
            get
            {
                return _cityList;
            }
            set
            {
                _cityList = value;
                OnPropertyChanged("CityList");
            }
        }
        public ObservableCollection<Item> RegionList
        {
            get
            {
                return _regionList;
            }
            set
            {
                _regionList = value;
                OnPropertyChanged("RegionList");
            }
        }
        public ObservableCollection<Item> AccountList
        {
            get
            {
                return _accountList;
            }
            set
            {
                _accountList = value;
                OnPropertyChanged("AccountList");
            }
        }
        public ObservableCollection<SetupCountryListItemModel> ListItems
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
        public SetupCountryItemViewModel _country;
        public SetupCountryItemViewModel Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }
        private SetupCountryItemViewModel filters;
        public void InitLists()
        {
            AccountList = repo.GetAccountList();
            CountryList = repo.GetCountryList();
            //
            //RegionList = repo.GetRegionList()
        }
        private void ClearForm()
        {
            try
            {
                Country.clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowData(SetupCountryModel? model)
        {
            if (model != null)
            {
                Country.FromModel(model);
            }
        }
        public void LoadData()
        {
            try
            {
                if (InvoiceToEditIndex != -1)
                {
                    CurrentRow = -1;
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "0", Id: ListItems[InvoiceToEditIndex].CountryId.ToString());
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
                var res = repo.Post(Country.ToModel());
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
                if (Country.CountryId != null && !Country.CountryId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "1", prev: "0", Id: Country.CountryId.ToString());
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
                if (Country.CountryId != null && !Country.CountryId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "1", Id: Country.CountryId.ToString());
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
