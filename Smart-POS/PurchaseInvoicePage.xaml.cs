using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Smart_POS.Validators;
using Smart_POS.ViewModels;
using MessageBox = System.Windows.MessageBox;

namespace POS_Desktop
{

    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int integer = (int)value;
            if (integer == int.Parse(parameter.ToString()))
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    /// <summary>
    /// Interaction logic for PurchaseInvoicePage.xaml
    /// </summary>
    public partial class PurchaseInvoicePage : Window
    {
        PurchaseInvoiceViewModel viewModel;

        public PurchaseInvoicePage()
        {
            InitializeComponent();
            viewModel = (PurchaseInvoiceViewModel)LayoutRoot.DataContext;

            ProductComboBox.ItemsSource = viewModel.ProductList;
            //viewModel.initLists();
        }

        private void ProductSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedValue != null && !comboBox.SelectedValue.Equals(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId))
            {
                viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId = comboBox?.SelectedValue.ToString();
                viewModel.GetProductPrice();
            }
        }
        private void ProductUnitSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                if (comboBox?.SelectedValue != null && !comboBox.SelectedValue.Equals(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductUnitId))
                {
                    viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductUnitId = comboBox?.SelectedValue.ToString();
                    viewModel.GetProductUnitPrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DetailsGrid.Items.Count.ToString());
            if (viewModel.CurrentRow >= 0 && viewModel.InvoiceDetailItems.Count > 0 && viewModel.CurrentRow < viewModel.InvoiceDetailItems.Count)
            {
                //viewModel.InvoiceDetailItems.RemoveAt(viewModel.CurrentRow);
            }
        }

        private void DetailsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.DisplayIndex == 2 || e.Column.DisplayIndex == 4 || e.Column.DisplayIndex == 6 || e.Column.DisplayIndex == 9)
            {
                viewModel.RecalcPrice();
            }
            if (e.Column.DisplayIndex == 0)
            {
                TextBox t = e.EditingElement as TextBox;
                string productBarcode = t.Text.ToString();
                viewModel.GetProductPriceByBarcode(productBarcode);
            }
        }

        private void deferredInvoiceBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (deferredInvoiceBtn.IsChecked == true)
            {
                PaidAmountTxt.IsReadOnly = false;
                DeferredAmountTxt.IsReadOnly = false;
            }
            else
            {
                PaidAmountTxt.IsReadOnly = true;
                DeferredAmountTxt.IsReadOnly = true;
            }
        }

        private void bankBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (bankBtn.IsChecked == true)
            {
                PaidCashTxt.IsReadOnly = false;
                PaidBankTxt.IsReadOnly = false;
                BankList.IsEnabled = true;
            }
            else
            {
                PaidCashTxt.IsReadOnly = true;
                PaidBankTxt.IsReadOnly = true;
                BankList.IsEnabled = false;
            }


        }

        private void New_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.IsValid(this)) // is valid
            {
                MessageBox.Show("isValid");
            }
            else
            {
                MessageBox.Show("isNotValid");
            }
        }
    }
}
