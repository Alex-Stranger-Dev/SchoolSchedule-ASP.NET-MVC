using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Models;
using SchoolSchedule.Managers;

namespace SchoolSchedule.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentManager _studentManager;

        public StudentController()
        {
            _studentManager = new StudentManager();
        }

        public ActionResult Index()
        {
            var student = _studentManager.GetStudent();
            return View(student);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var student = _studentManager.GetOneStudent(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Добавьте логику обновления
                    return Json(new { success = true, message = "Successfully updated" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error updating record" });
                }
            }
            return Json(new { success = false, message = "Invalid model state" });
        }






    }

}

// Другие методы для создания, редактирования и удаления записей расписания