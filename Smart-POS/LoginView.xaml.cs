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
using System.Net.Http;
using Newtonsoft.Json;
using POS_Desktop.Models;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;

namespace POS_Desktop
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : System.Windows.Controls.UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginModel login = new()
            {
                username = UsernameTxt.Text,
                password = PasswordTxt.Password
            };


            var json = JsonConvert.SerializeObject(login);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var response = client.PostAsync($"http://localhost:8000/ords/accounting/trade_v1/auth", data).Result;

            var res = JsonConvert.DeserializeObject<LoginResponseModel>(response.Content.ReadAsStringAsync().Result);

            if (res != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var currentWin = Application.Current.Windows[0];
                currentWin.Hide();
                MainWindow mainW = new MainWindow();
                mainW.Show();
                currentWin.Close();
            }
            else
            {
                MessageBox.Show(res.message);
            }
            //MessageBox.Show(response.StatusCode.ToString());

        }
    }
}
