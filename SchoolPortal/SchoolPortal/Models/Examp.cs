using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPortal.Models
{
    internal class Examp
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public SolidColorBrush Color
        {
            get
            {
                if (Mark == "2")
                {
                    return new SolidColorBrush(Colors.IndianRed);
                }
                else if (Mark == "3")
                {
                    return new SolidColorBrush(Colors.Orange);
                }
                else if (Mark == "4" || Mark == "5")
                {
                    return new SolidColorBrush(Colors.LawnGreen);
                }
                else
                {
                    return new SolidColorBrush(Colors.Blue);

                }
            }
        }
    }
}
