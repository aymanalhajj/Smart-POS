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
    /// Interaction logic for PurchaseInvoicePage.xaml
    /// </summary>
    public partial class StockOutOrderPage : Window
    {
        StockOutOrderViewModel viewModel;
        public StockOutOrderPage()
        {
            InitializeComponent();
            viewModel = (StockOutOrderViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new StockOutOrderViewModel.ValidateCallbackEventHandler(ValidateForm);
            ProductComboBox.ItemsSource = viewModel.ProductList;
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
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedValue != null && !comboBox.SelectedValue.Equals(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId))
            {
                viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductId = comboBox?.SelectedValue.ToString();
                viewModel.GetProductPrice();
            }
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

        private void InvoicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void InvoicesList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            viewModel.LoadInvoiceData();
            myTab.SelectedIndex = 0;
        }

    }
}
