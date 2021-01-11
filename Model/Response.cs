using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Model
{
    public class Response
    {
        public int code { get; set; }
        public string content { get; set; }
        public Model.Captcha captcha { get; set; }
        public Model.User user { get; set; }
        public Model.Upcoming upcoming { get; set; }
    }
}
