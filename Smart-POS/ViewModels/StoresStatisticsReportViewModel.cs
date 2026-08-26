using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class StoresStatisticsReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();
        private const int PageSize = 20;

        public StoresStatisticsReportViewModel()
        {
            StoreList = repo.GetStoreList();
            Results = new ObservableCollection<StoresStatisticsRow>();
        }

        public ObservableCollection<Item> StoreList { get; set; }

        private string? _storeId;
        public string? StoreId { get => _storeId; set { _storeId = value; OnPropertyChanged(nameof(StoreId)); } }

        private ObservableCollection<StoresStatisticsRow> _results;
        public ObservableCollection<StoresStatisticsRow> Results { get => _results; set { _results = value; OnPropertyChanged(nameof(Results)); } }

        private int _page = 1;
        public int Page { get => _page; set { _page = value; OnPropertyChanged(nameof(Page)); } }

        private int _total;
        public int Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        private void Search()
        {
            var res = repo.GetStoresStatistics(StoreId, Page, PageSize);
            Results = new ObservableCollection<StoresStatisticsRow>(res.Items ?? new List<StoresStatisticsRow>());
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
                    { "P_STORE_ID", StoreId ?? "" },
                };
                var bytes = repo.GetReportPdf("stores_statistics_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "stores_statistics");
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
