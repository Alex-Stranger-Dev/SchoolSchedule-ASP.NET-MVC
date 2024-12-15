using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Models;
using SchoolSchedule.Managers;

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
            var teacher = _teacherManager.GetTeacher();
            return View(teacher);
        }


        public ActionResult Details(int Id)
        {
            var teacher = _teacherManager.GetOneTeacher(Id);
            return View(teacher);
        }

        public ActionResult InsertForm()
        {
            ViewBag.Teacher = new SelectList(_teacherManager.GetTeacher(), "LastName", "LastName");
            return View();
        }


        //public ActionResult InsertForm()
        //{
        //    ViewBag.Teacher = _teacherManager.GetTeacher();
        //    return View();
        //}



        //[HttpPost]
        //public ActionResult Insert(Teacher teacher)
        //{
        //    if (teacher.Id == 0)
        //    {
        //        // Проверка на наличие учителя с таким же LastName, если нет, добавляем как нового
        //        var existingTeacher = _teacherManager.GetTeacher().FirstOrDefault(t => t.LastName == teacher.LastName);
        //        if (existingTeacher != null)
        //        {
        //            teacher.Id = existingTeacher.Id; // Используем существующего учителя
        //        }
        //        else
        //        {
        //            _teacherManager.AddNew(teacher);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Insert(Teacher teacher)
        {
            // Проверка на наличие учителя с таким же LastName
            var existingTeacher = _teacherManager.GetTeacher().FirstOrDefault(t => t.LastName == teacher.LastName);
            if (existingTeacher != null)
            {
                ViewBag.ErrorMessage = "Учитель с такой фамилией уже существует!";
                ViewBag.Teacher = _teacherManager.GetTeacher();
                return View("InsertForm");
            }

            // Добавляем нового учителя
            _teacherManager.AddNew(teacher);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            _teacherManager.Update(teacher);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            _teacherManager.Delete(Id);
            return RedirectToAction("Index");
        }


    }
}

