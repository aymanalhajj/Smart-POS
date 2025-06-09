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
    /// Interaction logic for SetupBranchPage.xaml
    /// </summary>
    public partial class SetupBranchPage : Window
    {
        SetupBranchViewModel viewModel;
        public SetupBranchPage()
        {
            InitializeComponent();
            viewModel = (SetupBranchViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new SetupBranchViewModel.ValidateCallbackEventHandler(ValidateForm);
            //ProductComboBox.ItemsSource = viewModel.ProductList;
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

        private void InvoicesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }


    }
}
