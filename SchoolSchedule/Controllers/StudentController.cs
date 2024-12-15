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
                    _studentManager.UpdateStudent(student);
                    return Json(new { success = true, message = "Successfully updated" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error updating record" });
                }
            }
            return Json(new { success = false, message = "Invalid model state" });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _studentManager.DeleteStudent(id);
                return Json(new { success = true, message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error deleting record" });
            }
        }


        public ActionResult InsertForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentManager.AddNewStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }



    }

}

