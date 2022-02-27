using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponseClass
    {
        public ResponseClass(DataBase.Class _Class)
        {
            Id = _Class.Id;
            ClassName = _Class.Year + " " + _Class.Symbol;
        }
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}