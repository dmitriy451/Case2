using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Models
{
    internal class TimeTableDay
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson { get
            {
                return $"{Сount}. {Name}";
            } }
    }
}
