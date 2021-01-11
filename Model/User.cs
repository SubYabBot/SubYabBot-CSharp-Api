using System;
using System.Collections.Generic;
using System.Text;

namespace SubYabBot_API.Model
{
    public class User
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
