using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class SafeBalancesReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();
        private const int PageSize = 20;

        public SafeBalancesReportViewModel()
        {
            SafeList = repo.GetSafeList();
            FromDate = new DateTime(DateTime.Today.Year, 1, 1);
            ToDate = DateTime.Today;
            Results = new ObservableCollection<SafeBalanceRow>();
        }

        public ObservableCollection<Item> SafeList { get; set; }

        private DateTime? _fromDate;
        public DateTime? FromDate { get => _fromDate; set { _fromDate = value; OnPropertyChanged(nameof(FromDate)); } }

        private DateTime? _toDate;
        public DateTime? ToDate { get => _toDate; set { _toDate = value; OnPropertyChanged(nameof(ToDate)); } }

        private string? _safeId;
        public string? SafeId { get => _safeId; set { _safeId = value; OnPropertyChanged(nameof(SafeId)); } }

        private ObservableCollection<SafeBalanceRow> _results;
        public ObservableCollection<SafeBalanceRow> Results { get => _results; set { _results = value; OnPropertyChanged(nameof(Results)); } }

        private int _page = 1;
        public int Page { get => _page; set { _page = value; OnPropertyChanged(nameof(Page)); } }

        private int _total;
        public int Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        private void Search()
        {
            var res = repo.GetSafeBalances(FromDate, ToDate, SafeId, Page, PageSize);
            Results = new ObservableCollection<SafeBalanceRow>(res.Items ?? new List<SafeBalanceRow>());
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
                    { "P_FROM_DATE", FromDate?.ToString("dd-MM-yyyy") ?? "" },
                    { "P_TO_DATE", ToDate?.ToString("dd-MM-yyyy") ?? "" },
                    { "P_SAFE_ID", SafeId ?? "" },
                };
                var bytes = repo.GetReportPdf("account_balances_safe_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "safe_balances");
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
