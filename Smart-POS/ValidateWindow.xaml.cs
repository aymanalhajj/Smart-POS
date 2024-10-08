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

            //ProductComboBox.ItemsSource = viewModel.ProductList;
        }

    }
}
