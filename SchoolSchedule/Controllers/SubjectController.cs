using System.Web.Mvc;
using SchoolSchedule.Abstract;
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
            var subject = _subjectManager.GetListSubject();
            return View(subject);
        }


        //public ActionResult Details(int Id)
        //{
        //    var subject = _subjectManager.GetOneSubject(Id);
        //    return View(subject);
        //}


        public ActionResult Details(int Id)
        {
            var subject = _subjectManager.GetOneSubject(Id);
            if (subject == null)
            {
                return HttpNotFound(); // Вернуть 404, если объект не найден
            }
            return View(subject);
        }


        public ActionResult InsertForm()
        {
            ViewBag.Subject = _subjectManager.GetListSubject(); 
            return View();
        }
        [HttpPost] 
        public ActionResult Insert(Subject subject)
        {
            _subjectManager.AddNewSubject(subject); 
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Subject subject)
        {
            _subjectManager.UpdateSubject(subject);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _subjectManager.DeleteSubject(id);
            return RedirectToAction("Index");
        }

    }
}

