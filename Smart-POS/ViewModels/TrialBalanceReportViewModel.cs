using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class TrialBalanceReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();
        private const int PageSize = 20;

        public TrialBalanceReportViewModel()
        {
            CostCenterList = repo.GetCostCenterList();
            FromDate = new DateTime(DateTime.Today.Year, 1, 1);
            ToDate = DateTime.Today;
            Results = new ObservableCollection<TrialBalanceRow>();
        }

        public ObservableCollection<Item> CostCenterList { get; set; }

        private DateTime? _fromDate;
        public DateTime? FromDate { get => _fromDate; set { _fromDate = value; OnPropertyChanged(nameof(FromDate)); } }

        private DateTime? _toDate;
        public DateTime? ToDate { get => _toDate; set { _toDate = value; OnPropertyChanged(nameof(ToDate)); } }

        private string? _costCtrId;
        public string? CostCtrId { get => _costCtrId; set { _costCtrId = value; OnPropertyChanged(nameof(CostCtrId)); } }

        private bool _withMainAccs;
        public bool WithMainAccs { get => _withMainAccs; set { _withMainAccs = value; OnPropertyChanged(nameof(WithMainAccs)); } }

        private ObservableCollection<TrialBalanceRow> _results;
        public ObservableCollection<TrialBalanceRow> Results { get => _results; set { _results = value; OnPropertyChanged(nameof(Results)); } }

        private int _page = 1;
        public int Page { get => _page; set { _page = value; OnPropertyChanged(nameof(Page)); } }

        private int _total;
        public int Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        private void Search()
        {
            var res = repo.GetTrialBalance(FromDate, ToDate, CostCtrId, WithMainAccs, Page, PageSize);
            Results = new ObservableCollection<TrialBalanceRow>(res.Items ?? new List<TrialBalanceRow>());
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
                    { "P_COST_CNTR_ID", CostCtrId ?? "" },
                    { "P_WITH_MAIN_ACCS", WithMainAccs ? "1" : "0" },
                };
                var bytes = repo.GetReportPdf("trail_balance_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "trial_balance");
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
