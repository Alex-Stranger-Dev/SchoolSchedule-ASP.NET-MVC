using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Models;
using SchoolSchedule.Managers;
using SchoolSchedule.Data;

namespace SchoolSchedule.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectManager _subjectManager;
        private readonly SubjectDapper _subjectDapper;

        public SubjectController()
        {
            _subjectManager = new SubjectManager(_subjectDapper);
        }

        public ActionResult Index()
        {
            var subject = _subjectManager.GetListSubject();
            return View(subject);
        }


        public ActionResult Details(int Id)
        {
            var subject = _subjectManager.GetOneSubject(Id);
            return View(subject);
        }
        // Другие методы для создания, редактирования и удаления записей расписания
    }
}

