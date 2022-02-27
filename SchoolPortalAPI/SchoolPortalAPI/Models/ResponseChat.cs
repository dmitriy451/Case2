using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolPortalAPI.Models
{
    public class ResponseChat
    {
        public ResponseChat(DataBase.Chat chat)
        {
            Name = chat.User.Name;
            Text = chat.Text;
            Time = chat.Date.ToString("HH:mm");
        }
            public string Name { get; set; }
            public string Text { get; set; }
            public string Time { get; set; }
        
    }
}