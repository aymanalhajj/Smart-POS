using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Newtonsoft.Json;
using Smart_POS.Models;
using Smart_POS.Validators;
using Smart_POS.ViewModels;
using MessageBox = System.Windows.MessageBox;

namespace Smart_POS
{

    /// <summary>
    /// Interaction logic for SetupCurrencyPage.xaml
    /// </summary>
    public partial class SetupCurrencyPage : Window
    {
        SetupCurrencyViewModel viewModel;
        public SetupCurrencyPage()
        {
            InitializeComponent();
            viewModel = (SetupCurrencyViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new SetupCurrencyViewModel.ValidateCallbackEventHandler(ValidateForm);
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void DataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewModel.LoadData();
            myTab.SelectedIndex = 0;
        }
    }
}
