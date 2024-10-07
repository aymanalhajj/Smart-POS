using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using POS_Desktop.Models;
using Smart_POS.Models;

namespace POS_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using var client = new HttpClient();
            var response = client.GetAsync($"http://localhost:8000/ords/accounting/trade_v1/purchases_invoices").Result;

            var res = JsonConvert.DeserializeObject<InvoiceListModel>(response.Content.ReadAsStringAsync().Result);
            if (res != null)
            {
                foreach (var item in res.items)
                {
                    InvoicesList.Items.Add(item);
                }

            }

        }

        private void deferredInvoiceBtn_Checked(object sender, RoutedEventArgs e)
        {
        }

    }
}