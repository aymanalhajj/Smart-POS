using Smart_POS.Validators;
using Smart_POS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for SalesClient.xaml
    /// </summary>
    public partial class SalesClient : Window
    {
        public SalesClient()
        {
            InitializeComponent();
            viewModel = (ClientViewModel)LayoutRoot.DataContext;
            viewModel.ValidateCallback += new ClientViewModel.ValidateCallbackEventHandler(ValidateForm);
        }
        ClientViewModel viewModel;
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

        private void CountryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.LoadCity();
        }

        private void CityCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.LoadRegion();
        }

        private void DataList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
