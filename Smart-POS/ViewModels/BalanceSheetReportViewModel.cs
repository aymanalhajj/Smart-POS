using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Smart_POS.Models;
using Smart_POS.Repository;

namespace Smart_POS.ViewModels
{
    public class BalanceSheetReportViewModel : INotifyPropertyChanged
    {
        private readonly ReportsRepository repo = new ReportsRepository();

        public BalanceSheetReportViewModel()
        {
            CostCenterList = repo.GetCostCenterList();
            ToDate = DateTime.Today;
        }

        public ObservableCollection<Item> CostCenterList { get; set; }

        private DateTime? _toDate;
        public DateTime? ToDate { get => _toDate; set { _toDate = value; OnPropertyChanged(nameof(ToDate)); } }

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
                    { "P_TO_DATE", ToDate?.ToString("dd-MM-yyyy") ?? "" },
                    { "P_COST_CNTR_ID", CostCtrId ?? "" },
                };
                var bytes = repo.GetReportPdf("balance_sheet_report", pdfParams);
                if (bytes != null)
                {
                    Utils.OpenPdfBytes(bytes, "balance_sheet");
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
