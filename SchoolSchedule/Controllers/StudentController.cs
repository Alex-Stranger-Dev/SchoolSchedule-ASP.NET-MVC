using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Managers;
using SchoolSchedule.Models;
namespace SchoolSchedule.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentManager _studentManager;

        public  StudentController ()
        {
            _studentManager = new StudentManager();
        }

        public ActionResult Index()
        {
            var student = _studentManager.GetAllStudents();
            return View(student);
        }

        // Другие методы для создания, редактирования и удаления записей расписания
    }
}

