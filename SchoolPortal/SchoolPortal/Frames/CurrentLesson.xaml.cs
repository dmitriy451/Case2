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
    /// Логика взаимодействия для CurrentLesson.xaml
    /// </summary>
    public partial class CurrentLesson : Page
    {
        public CurrentLesson()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                var json = client.DownloadString($"http://localhost:64170/api/Lessons/{Models.Terminal.User.Id}");
                Lesson = JsonConvert.DeserializeObject<Models.CurrentLesson>(json);
                CurrentLessonText.Text = Lesson.CurrentLessonString;
                client = new WebClient();
                
                client.Encoding = System.Text.Encoding.UTF8;
                json = client.DownloadString($"http://localhost:64170/api/Groups/{Lesson.ClassId}");
                group = JsonConvert.DeserializeObject<List<Models.GroupLesson>>(json);
                Students.ItemsSource = group;
            }
            catch
            {
                CurrentLessonText.Text = "В данный момент уроков нет";
            }
        }
        Models.CurrentLesson Lesson;
        List<Models.GroupLesson> group;
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
            Models.Terminal.frame.Navigate(new Marks());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            var Marks = group.Where(p => p.Mark != "").ToList();
            foreach (var item in Marks)
            {
                group.Remove(item);
            }
            List<Models.Marks> marks = Marks.ConvertAll(p => new Models.Marks(p, Lesson));
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:64170/api/Marks");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(marks);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            MessageBox.Show("Оценки выставлены.");
        }
    }
}
