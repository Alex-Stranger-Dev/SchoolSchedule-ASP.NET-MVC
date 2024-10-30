using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolSchedule.Data;
using SchoolSchedule.Managers;
using SchoolSchedule.Models;
using System;
using SchoolSchedule.Abstract;

namespace UnitTest_SchoolSchedule
{
    [TestClass]
    public class SubjectManagerTest
    {
        [TestMethod]
        public void Should_GetOneSubject_When_EmptyObject_IsNotNull()
        {
            var dapperMock = new Mock<ISubjectDapper>();
            var manager = new SubjectManager(dapperMock.Object);

            var subject = new Subject();

            int id = 156;
            dapperMock.Setup(x => x.GetOneSubject(id)).Returns(subject);
            
            var result = manager.GetOneSubject(id);
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_GetOneSubject_When_Data_IsNotNull()
        {
            var dapperMock = new Mock<ISubjectDapper>();
            var manager = new SubjectManager(dapperMock.Object);

            var subject = new Subject
            {
                Id = 10,
                Name = "History",
                Class = "5"
            };

            int id = 10;
            dapperMock.Setup(x => x.GetOneSubject(id)).Returns(subject);

            var result = manager.GetOneSubject(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(subject.Id, result.Id); //первое - ожидаемое значение, второе - что пришло
            Assert.AreEqual("History",result.Name); 
        }
    }
}
