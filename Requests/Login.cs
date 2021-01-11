using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SubYabBot_API.Requests
{
    class Login : IRequest
    {
        public string email { get; set; }
        public string password { get; set; }
        public string captcha { get; set; }
    }
}
