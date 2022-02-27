using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponsLessonsMarks
    {
        public ResponsLessonsMarks(DataBase.Lessons lessons, int StudentId)
        {
            Lesson = lessons.Name;
            Mark = lessons.Marks.Where(p => p.StudentId == StudentId).ToList().ConvertAll(p => new ResponseMark() { Mark = p.Mark, Id = p.Id });


            double sum = 0;
            double count = 0;
            Midle = 0;
            foreach (var item in Mark)
            {
                try
                {
                    sum += Convert.ToInt32(item.Mark);
                    count += 1;
                }
                catch
                {
                }
            }
            if (count > 0)
            {
                Midle = sum / count;
                Midle = Math.Round(Midle, 2);
            }
        }
        public string Lesson { get; set; }
        public List<ResponseMark> Mark { get; set; }
        public double Midle { get; set; }
    }
}