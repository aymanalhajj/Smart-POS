using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class ProductTransactionsReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();
        private const int PageSize = 20;

        public ProductTransactionsReportViewModel()
        {
            ProductList = repo.GetProductList();
            Results = new ObservableCollection<ProductTransRow>();
        }

        public ObservableCollection<Item> ProductList { get; set; }

        private string? _productId;
        public string? ProductId { get => _productId; set { _productId = value; OnPropertyChanged(nameof(ProductId)); } }

        private ObservableCollection<ProductTransRow> _results;
        public ObservableCollection<ProductTransRow> Results { get => _results; set { _results = value; OnPropertyChanged(nameof(Results)); } }

        private int _page = 1;
        public int Page { get => _page; set { _page = value; OnPropertyChanged(nameof(Page)); } }

        private int _total;
        public int Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        private void Search()
        {
            var res = repo.GetProductTransactions(ProductId, Page, PageSize);
            Results = new ObservableCollection<ProductTransRow>(res.Items ?? new List<ProductTransRow>());
            Total = res.Total;
        }

        private void NextPage()
        {
            if (Page * PageSize >= Total) return;
            Page++;
            Search();
        }

        private void PrevPage()
        {
            if (Page <= 1) return;
            Page--;
            Search();
        }

        private void Print()
        {
            try
            {
                IsBusy = true;
                var pdfParams = new Dictionary<string, string>
                {
                    { "P_COMPANY_ID", repo.companyId },
                    { "P_LANG_ID", repo.langId },
                    { "P_PRODUCT_ID", ProductId ?? "" },
                };
                var bytes = repo.GetReportPdf("store_product_total_movements_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "product_transactions");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand SearchCommand => new RelayCommand(o => { Page = 1; Search(); });
        public ICommand PrintCommand => new RelayCommand(o => Print());
        public ICommand NextPageCommand => new RelayCommand(o => NextPage());
        public ICommand PrevPageCommand => new RelayCommand(o => PrevPage());

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
