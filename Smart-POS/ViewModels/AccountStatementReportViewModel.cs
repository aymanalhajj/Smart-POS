using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class AccountStatementReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();

        public AccountStatementReportViewModel()
        {
            AccountList = repo.GetAccountList();
            CostCenterList = repo.GetCostCenterList();
            FromDate = new DateTime(DateTime.Today.Year, 1, 1);
            ToDate = DateTime.Today;
        }

        public ObservableCollection<Item> AccountList { get; set; }
        public ObservableCollection<Item> CostCenterList { get; set; }

        private DateTime? _fromDate;
        public DateTime? FromDate { get => _fromDate; set { _fromDate = value; OnPropertyChanged(nameof(FromDate)); } }

        private DateTime? _toDate;
        public DateTime? ToDate { get => _toDate; set { _toDate = value; OnPropertyChanged(nameof(ToDate)); } }

        private string? _accountId;
        public string? AccountId { get => _accountId; set { _accountId = value; OnPropertyChanged(nameof(AccountId)); } }

        private string? _costCtrId;
        public string? CostCtrId { get => _costCtrId; set { _costCtrId = value; OnPropertyChanged(nameof(CostCtrId)); } }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(nameof(IsBusy)); } }

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
                    { "P_ACCOUNT_ID", AccountId ?? "" },
                    { "P_COST_CNTR_ID", CostCtrId ?? "" },
                };
                var bytes = repo.GetReportPdf("account_statement_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "account_statement");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand PrintCommand => new RelayCommand(o => Print());

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
