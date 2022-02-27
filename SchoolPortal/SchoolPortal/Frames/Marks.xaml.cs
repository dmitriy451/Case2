using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        public Marks()
        {
            InitializeComponent();


            if (Models.Terminal.User.Position.ToLower() == "ученик")
            {
            CBoxStudents.Visibility = Visibility.Collapsed;
            BtnCurrentLesson.Visibility = Visibility.Collapsed;
                UpdateMarks();
            }
            else
            {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/Users");
            List<Models.Peoples> Students = JsonConvert.DeserializeObject<List<Models.Peoples>>(json);
            CBoxStudents.ItemsSource = Students;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.Navigate(new TeachersAndFriends());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.Navigate(new TimeTable());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.Navigate(new CurrentLesson());
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateMarks();
        }
        void UpdateMarks()
        {
            if (CBoxStudents.SelectedItem != null)
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                var json = client.DownloadString($"http://localhost:64170/api/Marks?Studentid={(CBoxStudents.SelectedItem as Models.Peoples).Id}");
                List<Models.ExampleMark> LessonMark = JsonConvert.DeserializeObject<List<Models.ExampleMark>>(json);
                LviewMarks.ItemsSource = LessonMark;
                
            }
            if (Models.Terminal.User.Position.ToLower() == "ученик")
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                var json = client.DownloadString($"http://localhost:64170/api/Marks?Studentid={Models.Terminal.User.Id}");
                List<Models.ExampleMark> LessonMark = JsonConvert.DeserializeObject<List<Models.ExampleMark>>(json);
                LviewMarks.ItemsSource = LessonMark;
            }
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
            {
                ChangeMark changeMark = new ChangeMark();
                changeMark.ShowDialog();
                if (changeMark.DialogResult == true)
                {
                    if (((sender as ListView).SelectedItem as Models.Examp) != null)
                    {
                        ((sender as ListView).SelectedItem as Models.Examp).Mark = changeMark.TBoxMark.Text;
                        int id = ((sender as ListView).SelectedItem as Models.Examp).Id;
                        string mark = ((sender as ListView).SelectedItem as Models.Examp).Mark;

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:64170/api/Marks/{id}?mark={mark}");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "PUT";

                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = JsonConvert.SerializeObject(((sender as ListView).SelectedItem as Models.Examp));
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                        (sender as ListView).SelectedItem = null;

                        UpdateMarks();
                    }
                }
            }
        }
    }
}
