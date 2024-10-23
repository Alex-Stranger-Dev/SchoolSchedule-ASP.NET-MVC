using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSchedule.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
    }
}