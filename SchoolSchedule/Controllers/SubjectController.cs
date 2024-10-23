using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Managers;
using SchoolSchedule.Models;
namespace SchoolSchedule.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SubjectManager _subjectManager;

        public SubjectController()
        {
            _subjectManager = new SubjectManager();
        }

        public ActionResult Index()
        {
            var subject = _subjectManager.GetAllSubjects();
            return View(subject);
        }

        // Другие методы для создания, редактирования и удаления записей расписания
    }
}

