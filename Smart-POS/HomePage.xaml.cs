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
using System.Windows.Shapes;
using POS_Desktop;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
            }
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void PurchaseInvMenu_Click(object sender, RoutedEventArgs e)
        {

            //var currentWin = Application.Current.Windows[0];
            //currentWin.Hide();
            //MainWindow mainW = new MainWindow();
            //mainW.Show();
            //currentWin.Close();
            //page.ShowInTaskbar = false;
            PurchaseInvoicePage page = new PurchaseInvoicePage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void SaleInvMenu_Click(object sender, RoutedEventArgs e)
        {
            SaleInvoicePage page = new SaleInvoicePage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void PurchaseReturnInvMenu_Click(object sender, RoutedEventArgs e)
        {
            PurchaseReturnInvoicePage page = new PurchaseReturnInvoicePage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void SaleReturnInvMenu_Click(object sender, RoutedEventArgs e)
        {
            SaleReturnInvoicePage page = new SaleReturnInvoicePage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void StockOutOrderMenu_Click(object sender, RoutedEventArgs e)
        {
            StockOutOrderPage page = new StockOutOrderPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void StockInOrderMenu_Click(object sender, RoutedEventArgs e)
        {
            StockInOrderPage page = new StockInOrderPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void FirstPeriodStockMenu_Click(object sender, RoutedEventArgs e)
        {
            FirstPeriodStockPage page = new FirstPeriodStockPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void PurchaseOrderMenu_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderPage page = new PurchaseOrderPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void RentInvMenu_Click(object sender, RoutedEventArgs e)
        {
            RentInvoicePage page = new RentInvoicePage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProvMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesProvider page = new SalesProvider();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ClientMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesClient page = new SalesClient();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void StoreTrnasferMenu_Click(object sender, RoutedEventArgs e)
        {
            StoreTransferPage page = new StoreTransferPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void BranchMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupBranchPage page = new SetupBranchPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProductMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesProductPage page = new SalesProductPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void CurrencyMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupCurrencyPage page = new SetupCurrencyPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void BankMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupBankPage page = new SetupBankPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void CountryMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupCountryPage page = new SetupCountryPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void CityMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupCityPage page = new SetupCityPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void RegionMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupRegionPage page = new SetupRegionPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void UnitMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupUnitPage page = new SetupUnitPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProdUnitMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesProductUnitPage page = new SalesProductUnitPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProdFileMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesProductFilesPage page = new SalesProductFilesPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProdBarcodeMenu_Click(object sender, RoutedEventArgs e)
        {
            SalesProductBarcodesPage page = new SalesProductBarcodesPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void ProductGroupMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupProdGroupPage page = new SetupProdGroupPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
        private void TaxGroupMenu_Click(object sender, RoutedEventArgs e)
        {
            SetupTaxGroupPage page = new SetupTaxGroupPage();
            page.Owner = Application.Current.MainWindow;
            page.Show();
        }
    }
}
