using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SubYabBot_API.Requests
{
    public class Upcoming : IRequest
    {
        public enum Statuses
        {
            Translating=1, Editing, Completed
        }

        // Create
        public string title { get; set; }
        public string nickname { get; set; }
        public string teamname { get; set; }
        public int season { get; set; }
        public int episode { get; set; }

        // Update
        public int all_lines { get; set; }
        public int translated_lines { get; set; }
        public int status { get; set; }
    }
}
