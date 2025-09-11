using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using Smart_POS.Models;
using Smart_POS.Validators;
using Smart_POS.ViewModels;
using MessageBox = System.Windows.MessageBox;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for AccDisbursementVoucherPage.xaml
    /// </summary>
    public partial class AccDisbursementVoucherPage : Window
    {
        AccVoucherViewModel viewModel;
        public AccDisbursementVoucherPage()
        {
            InitializeComponent();
            viewModel = (AccVoucherViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new AccVoucherViewModel.ValidateCallbackEventHandler(ValidateForm);
            ProductComboBox.ItemsSource = viewModel.AccountList;
        }
        public bool ValidateForm()
        {
            var valid = Validator.IsValid(this);

            if (!valid)
            {
                MessageBox.Show("عذرا، يجب التاكد من اكمال ادخال البيانات");
            }
            return valid;
        }
        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DetailsGrid.Items.Count.ToString());
            if (viewModel.CurrentRow >= 0 && viewModel.InvoiceDetailItems.Count > 0 && viewModel.CurrentRow < viewModel.InvoiceDetailItems.Count)
            {
                viewModel.InvoiceDetailItems.RemoveAt(viewModel.CurrentRow);
            }
        }
        private void DetailsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.DisplayIndex == 1 || e.Column.DisplayIndex == 5 || e.Column.DisplayIndex == 8)
            {
                viewModel.RecalcPrice();
                decimal totalSum = 0;
                decimal totalVatt = 0;
                foreach (var item in viewModel.InvoiceDetailItems)
                {
                    totalSum += decimal.Parse(item.TotalAmount.ToString());
                    totalVatt += decimal.Parse(item.TaxAmount.ToString());
                }
                totalCreditor.Text = totalSum.ToString();
                totalVat.Text = totalVatt.ToString();
            }
        }
        private void InvoicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void InvoicesList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.LoadInvoiceData();
            myTab.SelectedIndex = 0;
        }
        private void checkBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (checkInvoiceBtn.IsChecked == true)
            {
                checkNoTxt.IsReadOnly = false;
                checkDatePicker.IsEnabled = true;
            }
            else
            {
                checkNoTxt.IsReadOnly = true;
                checkDatePicker.IsEnabled = false;
            }
        }
        private void vouAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            totalDebtor.Text = vouAmount.Text;
            if (totalDebtor.Text == "" || totalDebtor.Text == null)
            {
                vouAmount.Text = "0";
                totalDebtor.Text = "0";
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            totalDebtor.Text = "0";
            totalCreditor.Text = "0";
            totalVat.Text = "0";
            vouAmount.Text = "0";
            VoucherType.Text = "3";
        }
    }
}
