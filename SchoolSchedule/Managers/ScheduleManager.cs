using Dapper;
using SchoolSchedule.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using SchoolSchedule.Data;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;
using System;


namespace SchoolSchedule.Managers
{
    public class ScheduleManager
    {
        private readonly ScheduleDapper _scheduleDapper;
        

        public ScheduleManager()
        {
            _scheduleDapper = new ScheduleDapper();
        }



        public IEnumerable<Models.Schedule> GetSchedule()
        {
            {
                var schedule = _scheduleDapper.GetSchedule();

                return schedule;
            }
        }


        public Models.Schedule GetOneSchedule(int Id)
        {
            {
                return _scheduleDapper.GetOneSchedule(Id);
            }
        }   

            
        

        //internal object GetOneSchedule()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

