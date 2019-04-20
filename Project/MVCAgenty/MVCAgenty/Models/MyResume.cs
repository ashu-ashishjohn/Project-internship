using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAgenty.Models
{
    public class MyResume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Skills { get; set; }

        public string Experience { get; set; }
    }
}