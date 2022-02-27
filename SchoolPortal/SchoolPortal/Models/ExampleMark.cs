using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPortal.Models
{
    internal class ExampleMark
    {
        public string Lesson { get; set; }
        public List<Examp> Mark { get; set; }
        public double Midle { get; set; }
        public SolidColorBrush Color
        {
            get
            {
                if (Midle >= 0 && Midle < 2.5)
                {
                    return new SolidColorBrush(Colors.IndianRed);
                }
                else if (Midle >= 2.5 && Midle < 3.5)
                {
                    return new SolidColorBrush(Colors.Orange);
                }
                else
                {
                    return new SolidColorBrush(Colors.LawnGreen);
                }
            }
        }
        public bool Status
        {
            get
            {
                if (Terminal.User.Position =="Учитель")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
