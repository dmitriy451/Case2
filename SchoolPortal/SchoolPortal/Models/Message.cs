using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SchoolPortal.Models
{
    internal class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }

        public SolidColorBrush Color
        {
            get
            {
                if (Name == Terminal.Chater.Name)
                {
                    return new SolidColorBrush(Colors.LightGray);
                }
                else
                {
                    return new SolidColorBrush(Colors.LightBlue);
                }
            }
        }
        public HorizontalAlignment Aligment
        {
            get
            {
                HorizontalAlignment horizontalAlignment;
                if (Name == Terminal.Chater.Name)
                {
                    horizontalAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    horizontalAlignment = HorizontalAlignment.Right;
                }
                return horizontalAlignment;
            }

        }
    }
}
