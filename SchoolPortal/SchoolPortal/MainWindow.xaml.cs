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

namespace SchoolPortal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Frames.Authorization());
            Models.Terminal.frame = frame;
            MessageBox.Show(DateTime.Now.ToString("M, dddd, T"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        private void frame_ContentRendered(object sender, EventArgs e)
        {
            if (!frame.CanGoBack)
            {
                Back.Visibility = Visibility.Collapsed;
            }
            else
            {
                Back.Visibility = Visibility.Visible;
            }
        }
    }
}
