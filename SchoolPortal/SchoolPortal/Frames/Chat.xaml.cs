using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Windows.Threading;

namespace SchoolPortal.Frames
{
    /// <summary>
    /// Логика взаимодействия для Chat.xaml
    /// </summary>
    public partial class Chat : Page
    {
        public Chat()
        {
            
            InitializeComponent();
            if (Models.Terminal.Chater != null)
            {
                Nameq.Text = Models.Terminal.Chater.Namess;
            }
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/Chats?Senderid={Models.Terminal.User.Id}&RecipientID={Models.Terminal.Chater.Id}");
            List<Models.Message> Messages = JsonConvert.DeserializeObject<List<Models.Message>>(json);

            LView_Messages.ItemsSource = Messages;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Models.Terminal.Chater != null)
            {
                Nameq.Text = Models.Terminal.Chater.Namess;
            }
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString($"http://localhost:64170/api/Chats?Senderid={Models.Terminal.User.Id}&RecipientID={Models.Terminal.Chater.Id}");
            List<Models.Message> Messages = JsonConvert.DeserializeObject<List<Models.Message>>(json);
            LView_Messages.ItemsSource = Messages;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://localhost:64170/api/Chats?text={Text.Text}&SenderId={Models.Terminal.User.Id}&RecipientId={Models.Terminal.Chater.Id}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string Message = JsonConvert.SerializeObject(new Models.Message());

                streamWriter.Write(Message);
                streamWriter.Flush();
                streamWriter.Close();
            }
            DateTime.Now.ToString("M dddd T");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Text.Text = "";
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            var json = client.DownloadString("http://localhost:64170/api/Chats?Senderid=1&RecipientID=4");
            List<Models.Message> Messages = JsonConvert.DeserializeObject<List<Models.Message>>(json);
            LView_Messages.ItemsSource = Messages;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Models.Terminal.frame.GoBack();
        }
    }
}
