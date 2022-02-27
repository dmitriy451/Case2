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
    /// Логика взаимодействия для TeachersAndFriends.xaml
    /// </summary>
    public partial class TeachersAndFriends : Page
    {
        public TeachersAndFriends()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/Users/{Models.Terminal.User.Id}");
            List<Models.Peoples> LFriends = JsonConvert.DeserializeObject<List<Models.Peoples>>(json);
            Friends.ItemsSource = LFriends;
        }

        private void Friends_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Friends.SelectedItem != null)
            {
                Models.Terminal.Chater = (Friends.SelectedItem as Models.Peoples);
                Models.Terminal.Chater.Namess = Models.Terminal.Chater.Name;
                Models.Terminal.Name = Models.Terminal.Chater.Name;
                Models.Terminal.frame.Navigate(new Frames.Chat());
            }
        }
    }
}
