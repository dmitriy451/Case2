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

namespace SchoolPortal
{
    /// <summary>
    /// Логика взаимодействия для ChangeMark.xaml
    /// </summary>
    public partial class ChangeMark : Window
    {
        public ChangeMark()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxMark.Text == "2" || TBoxMark.Text == "3" || TBoxMark.Text == "4" || TBoxMark.Text == "5" || TBoxMark.Text == "Н")
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Оценка должна быть одной из: 2, 3, 4, 5, Н");
            }

        }
    }
}
