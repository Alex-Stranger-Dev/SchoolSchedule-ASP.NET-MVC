using System.Web.Mvc;
using Moq;
using SchoolSchedule.Controllers;
using SchoolSchedule.Managers;
using SchoolSchedule.Models;
using Xunit;

namespace SchoolSchedule.Tests
{
    public class TeacherControllerTests
    {
        private readonly Mock<TeacherManager> _teacherManagerMock;
        private readonly TeacherController _controller;

        public TeacherControllerTests()
        {
            _teacherManagerMock = new Mock<TeacherManager>();
            _controller = new TeacherController(_teacherManagerMock.Object);
        }

        [Fact]
        public void Insert_Returns_View_With_Errors_When_Model_Is_Invalid()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var result = _controller.Insert(new Teacher()) as ViewResult;

            Assert.NotNull(result);
            Assert.False(_controller.ModelState.IsValid);
        }

        [Fact]
        public void Insert_Returns_View_With_ErrorMessage_When_Teacher_Already_Exists()
        {
            _teacherManagerMock.Setup(m => m.GetTeacher())
                .Returns(new List<Teacher> { new Teacher { LastName = "Existing" } });

            var result = _controller.Insert(new Teacher { LastName = "Existing" }) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Учитель с такой фамилией уже существует!", _controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [Fact]
        public void Insert_Redirects_To_Index_When_Successful()
        {
            var teacher = new Teacher { Name = "Name", LastName = "LastName", Subject = "Subject" };

            var result = _controller.Insert(teacher) as RedirectToRouteResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.RouteValues["action"]);
        }
    }
}
