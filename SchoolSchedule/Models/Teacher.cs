using System.ComponentModel.DataAnnotations;

namespace SchoolSchedule.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
    }
}
