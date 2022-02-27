using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Models
{
    internal class TimeTable
    {
        public Monday[] Monday { get; set; }
        public Tuesday[] Tuesday { get; set; }
        public Wednesday[] Wednesday { get; set; }
        public Thursday[] Thursday { get; set; }
        public Friday[] Friday { get; set; }
    }

    public class Monday
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson
        {
            get
            {
                return $"{Сount}. {Name}";
            }
        }
    }

    public class Tuesday
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson
        {
            get
            {
                return $"{Сount}. {Name}";
            }
        }
    }

    public class Wednesday
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson
        {
            get
            {
                return $"{Сount}. {Name}";
            }
        }
    }

    public class Thursday
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson
        {
            get
            {
                return $"{Сount}. {Name}";
            }
        }
    }

    public class Friday
    {
        public int Сount { get; set; }
        public string Name { get; set; }
        public string Lesson
        {
            get
            {
                return $"{Сount}. {Name}";
            }
        }
    }







}
