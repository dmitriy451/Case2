using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace SchoolPortal.Frames
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                var json = client.DownloadString($"http://localhost:64170/api/Users?login={login.Text}&password={password.Text}");
                Models.Terminal.User = JsonConvert.DeserializeObject<Models.Peoples>(json);
                if (Models.Terminal.User.Position.ToLower() == "учитель")
                {
                    Models.Terminal.frame.Navigate(new CurrentLesson());
                }
                else
                {
                    Models.Terminal.frame.Navigate(new Marks());
                }
            }
            catch
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
