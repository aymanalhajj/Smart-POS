using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class IncomeStatementReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();
        private const int PageSize = 20;

        public IncomeStatementReportViewModel()
        {
            CostCenterList = repo.GetCostCenterList();
            ToDate = DateTime.Today;
            Results = new ObservableCollection<IncomeStatementRow>();
        }

        public ObservableCollection<Item> CostCenterList { get; set; }

        private DateTime? _toDate;
        public DateTime? ToDate { get => _toDate; set { _toDate = value; OnPropertyChanged(nameof(ToDate)); } }

        private string? _costCtrId;
        public string? CostCtrId { get => _costCtrId; set { _costCtrId = value; OnPropertyChanged(nameof(CostCtrId)); } }

        private bool _withMainAccs;
        public bool WithMainAccs { get => _withMainAccs; set { _withMainAccs = value; OnPropertyChanged(nameof(WithMainAccs)); } }

        private ObservableCollection<IncomeStatementRow> _results;
        public ObservableCollection<IncomeStatementRow> Results { get => _results; set { _results = value; OnPropertyChanged(nameof(Results)); } }

        private int _page = 1;
        public int Page { get => _page; set { _page = value; OnPropertyChanged(nameof(Page)); } }

        private int _total;
        public int Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

        private void Search()
        {
            var res = repo.GetIncomeStatement(ToDate, CostCtrId, WithMainAccs, Page, PageSize);
            Results = new ObservableCollection<IncomeStatementRow>(res.Items ?? new List<IncomeStatementRow>());
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
                    { "P_TO_DATE", ToDate?.ToString("dd-MM-yyyy") ?? "" },
                    { "P_COST_CNTR_ID", CostCtrId ?? "" },
                    { "P_FOR_MAIN_ACCS", WithMainAccs ? "1" : "0" },
                };
                var bytes = repo.GetReportPdf("income_statement_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "income_statement");
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
