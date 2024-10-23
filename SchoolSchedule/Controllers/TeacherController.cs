using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Managers;
using SchoolSchedule.Models;
namespace SchoolSchedule.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherManager _teacherManager;

        public TeacherController()
        {
            _teacherManager = new TeacherManager();
        }

        public ActionResult Index()
        {
            var teacher = _teacherManager.GetAllTeachers();
            return View(teacher);
        }

        // Другие методы для создания, редактирования и удаления записей расписания
    }
}

