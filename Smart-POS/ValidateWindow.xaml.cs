using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Smart_POS.Validators;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for ValidateWindow.xaml
    /// </summary>
    public partial class ValidateWindow : Window
    {
        public ValidateWindow()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //Binding binding = BindingOperations.GetBinding(textBox1, TextBox.TextProperty);
            if (Validator.IsValid(this)) // is valid
            {
                MessageBox.Show("isValid");
                Binding binding = BindingOperations.GetBinding(StoreList, System.Windows.Controls.Primitives.Selector.SelectedValueProperty);
                SelectListValidator vr = new SelectListValidator();
                binding.ValidationRules.Add(vr);

            }
            else
            {
                MessageBox.Show("isNotValid");
                Binding binding = BindingOperations.GetBinding(StoreList, System.Windows.Controls.Primitives.Selector.SelectedValueProperty);
                binding.ValidationRules.Clear();
                Validator.IsValid(this);
            }
            
        }
    }
}
