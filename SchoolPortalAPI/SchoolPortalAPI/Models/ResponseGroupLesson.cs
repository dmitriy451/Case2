using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponseGroupLesson
    {
        public ResponseGroupLesson(DataBase.Group group)
        {
            Id = group.StudentId;
            Name = group.User.Name;
            Comment = "";
            Mark = "";
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Mark { get; set; }
    }
}