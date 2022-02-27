using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponcseLesson
    {
        public ResponcseLesson( DataBase.TimeTable timeTable)
        {
            CurrentLessonString = $"{DateTime.Now.ToString("M")}, {DateTime.Now.DayOfWeek}, {timeTable.Count} урок, {timeTable.Lessons.Name}";
            ClassId = timeTable.ClassId;
        }
        public string CurrentLessonString { get; set; }
        public int ClassId { get; set; }

    }
}