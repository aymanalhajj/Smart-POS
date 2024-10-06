using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Smart_POS.Validators;
using Smart_POS.ViewModels;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for ValidateWindow.xaml
    /// </summary>
    public partial class ValidateWindow : Window
    {
        PurchaseInvoiceViewModel viewModel;
        public ValidateWindow()
        {
            InitializeComponent();
            viewModel = (PurchaseInvoiceViewModel)LayoutRoot.DataContext;

            ProductComboBox.ItemsSource = viewModel.ProductList;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //Binding binding = BindingOperations.GetBinding(textBox1, TextBox.TextProperty);
            if (Validator.IsValid(this)) // is valid
            {
                MessageBox.Show("isValid");
                //Binding binding = BindingOperations.GetBinding(StoreList, System.Windows.Controls.Primitives.Selector.SelectedValueProperty);
                //SelectListValidator vr = new SelectListValidator();
                //binding.ValidationRules.Add(vr);

            }
            else
            {
                MessageBox.Show("isNotValid");
                //Binding binding = BindingOperations.GetBinding(StoreList, System.Windows.Controls.Primitives.Selector.SelectedValueProperty);
                //binding.ValidationRules.Clear();
                //Validator.IsValid(this);
            }
            
        }

        private void deferredInvoiceBtn_Checked(object sender, RoutedEventArgs e)
        {

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

        private void bankBtn_Checked(object sender, RoutedEventArgs e)
        {

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
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedValue != null && !comboBox.SelectedValue.Equals(viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductUnitId))
            {
                viewModel.InvoiceDetailItems[viewModel.CurrentRow].ProductUnitId = comboBox?.SelectedValue.ToString();
                viewModel.GetProductUnitPrice();
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

    }
}
