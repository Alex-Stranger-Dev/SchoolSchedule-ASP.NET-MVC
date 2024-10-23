﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolSchedule.Models;
using SchoolSchedule.Managers;

namespace SchoolSchedule.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleManager _scheduleManager;

        public ScheduleController()
        {
            _scheduleManager = new ScheduleManager();
        }

        public ActionResult Index()
        {
            var schedule = _scheduleManager.GetSchedule();
            return View(schedule);
        }

        // Другие методы для создания, редактирования и удаления записей расписания
    }
}
