using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponseTimeTableDay
    {
        public ResponseTimeTableDay(int count)
        {
            Сount = count;
            Name = "Пусто";
        }
        public ResponseTimeTableDay(DataBase.TimeTable timeTable)
        {
            Сount = timeTable.Count;
            Name = timeTable.Lessons.Name;
        }
        public int Сount { get; set; }
        public string Name { get; set; }
    }
}