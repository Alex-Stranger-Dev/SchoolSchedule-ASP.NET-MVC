using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSchedule.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public string Subject { get; set; }
        public string TeacherLastName { get; set; }
    }
}