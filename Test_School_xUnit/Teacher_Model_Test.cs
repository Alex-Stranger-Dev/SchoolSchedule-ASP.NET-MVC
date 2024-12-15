using System.ComponentModel.DataAnnotations;
using System.Linq;
using SchoolSchedule.Models;
using Xunit;

namespace SchoolSchedule.Tests
{
    public class TeacherModelTests
    {
        [Fact]
        public void Teacher_Name_Is_Required()
        {
            var teacher = new Teacher { LastName = "LastName", Subject = "Subject" };
            var context = new ValidationContext(teacher, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(teacher, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, v => v.MemberNames.Contains("Name") && v.ErrorMessage == "Name is required");
        }

        [Fact]
        public void Teacher_LastName_Is_Required()
        {
            var teacher = new Teacher { Name = "Name", Subject = "Subject" };
            var context = new ValidationContext(teacher, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(teacher, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, v => v.MemberNames.Contains("LastName") && v.ErrorMessage == "Last Name is required");
        }

        [Fact]
        public void Teacher_Subject_Is_Required()
        {
            var teacher = new Teacher { Name = "Name", LastName = "LastName" };
            var context = new ValidationContext(teacher, null, null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(teacher, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, v => v.MemberNames.Contains("Subject") && v.ErrorMessage == "Subject is required");
        }
    }
}

