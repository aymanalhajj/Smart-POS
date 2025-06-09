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
    /// Interaction logic for SalesProductUnitPage.xaml
    /// </summary>
    public partial class SalesProductUnitPage : Window
    {
        SalesProductUnitViewModel viewModel;
        public SalesProductUnitPage()
        {
            InitializeComponent();
            viewModel = (SalesProductUnitViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new SalesProductUnitViewModel.ValidateCallbackEventHandler(ValidateForm);
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
        private void DataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewModel.LoadData();
            myTab.SelectedIndex = 0;
        }
        private void ProductCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //viewModel.LoadCity();
        }
        private void UnitCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //viewModel.LoadCity();
        }
    }
}