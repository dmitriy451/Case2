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
    /// Логика взаимодействия для TimeTable.xaml
    /// </summary>
    public partial class TimeTable : Page
    {
        public TimeTable()
        {
            InitializeComponent();

            if (Models.Terminal.User.Position.ToLower() == "ученик")
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                var json = client.DownloadString($"http://localhost:64170/api/TimeTables/{Models.Terminal.User.Id}?ClassId={2}");
                Models.TimeTable timeTable = JsonConvert.DeserializeObject<Models.TimeTable>(json);
                this.DataContext = timeTable;
                CBoxClasses.Visibility = Visibility.Collapsed;
                BtnCurrentLesson.Visibility = Visibility.Collapsed;
            }
            else
            {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/Classes");
            List<Models.Classes> classes = JsonConvert.DeserializeObject<List<Models.Classes>>(json);
            CBoxClasses.ItemsSource = classes;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.Navigate(new Frames.CurrentLesson());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.Navigate(new Frames.TeachersAndFriends());
        }

        private void CBoxClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CBoxClasses.SelectedItem != null)
            {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/TimeTables/{Models.Terminal.User.Id}?ClassId={(CBoxClasses.SelectedItem as Models.Classes).Id}");
            Models.TimeTable timeTable = JsonConvert.DeserializeObject<Models.TimeTable>(json);
            this.DataContext = timeTable;
            }
        }
    }
}
