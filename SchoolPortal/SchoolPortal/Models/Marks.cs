using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Models
{
    internal class Marks
    {
        public Marks(GroupLesson groupLesson, CurrentLesson currentLesson)
        {
            StudentId = groupLesson.Id;
            LessonId = currentLesson.LessonId;
            Mark = groupLesson.Mark[0].ToString();
            Comment = groupLesson.Comment;
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public string Mark { get; set; }
        public string Comment { get; set; }
        public System.DateTime Date { get; set; }
    }
}
