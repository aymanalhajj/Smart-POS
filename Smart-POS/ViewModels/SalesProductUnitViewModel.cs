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
    internal class SalesProductUnitViewModel : INotifyPropertyChanged
    {
        public SalesProductUnitViewModel()
        {
            repo = new SalesProductUnitRepo();
            Unit = new SalesProductUnitItemViewModel();
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
        private SalesProductUnitRepo repo { get; set; }
        public int CurrentRow { get; set; }
        public int InvoiceToEditIndex { get; set; }
        private SalesProductUnitItemViewModel unit;
        private ObservableCollection<SalesProductUnitListItemModel> _ListItems;
        private ObservableCollection<Item> _unitList;
        public ObservableCollection<Item> UnitList
        {
            get
            {
                return _unitList;
            }
            set
            {
                _unitList = value;
                OnPropertyChanged("UnitList");
            }
        }
        private ObservableCollection<Item> _productList;
        public ObservableCollection<Item> ProductList
        {
            get
            {
                return _productList;
            }
            set
            {
                _productList = value;
                OnPropertyChanged("ProductList");
            }
        }
        public ObservableCollection<SalesProductUnitListItemModel> ListItems
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
        public SalesProductUnitItemViewModel _unit;
        public SalesProductUnitItemViewModel Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                OnPropertyChanged("Unit");
            }
        }
        private SalesProductUnitItemViewModel filters;
        public void InitLists()
        {
            ProductList = repo.GetProductList();
            UnitList = repo.GetUnitList();
        }
        private void ClearForm()
        {
            try
            {
                Unit.clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowData(SalesProductUnitModel? model)
        {
            if (model != null)
            {
                Unit.FromModel(model);
            }
        }
        public void LoadData()
        {
            try
            {
                if (InvoiceToEditIndex != -1)
                {
                    CurrentRow = -1;
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "0", Id: ListItems[InvoiceToEditIndex].ProductUnitId.ToString());
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
                var res = repo.Post(Unit.ToModel());
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
                if (Unit.ProductUnitId != null && !Unit.ProductUnitId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "1", prev: "0", Id: Unit.ProductUnitId.ToString());
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
                if (Unit.ProductUnitId != null && !Unit.ProductUnitId.Equals("0"))
                {
                    var res = repo.Get(first: "0", last: "0", next: "0", prev: "1", Id: Unit.ProductUnitId.ToString());
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

