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
using Smart_POS.Models;
using Smart_POS.Repository;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;

namespace Smart_POS
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
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

            try
            {
                var client = ApiRepository.getInstance().MyClient();
                var response = client.PostAsync("https://localhost:7081/api/auth/login", data).Result;

                var res = JsonConvert.DeserializeObject<LoginResponseModel>(response.Content.ReadAsStringAsync().Result);

                if (res != null && response.StatusCode == System.Net.HttpStatusCode.OK && res.Success)
                {
                    ApiRepository.getInstance().SetAuthToken(res.Token);
                    ApiRepository.getInstance().companyId = res.CompanyId?.ToString() ?? "1";

                    var home = new HomePage();
                    Application.Current.MainWindow = home;
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res?.Message ?? "فشل تسجيل الدخول");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
