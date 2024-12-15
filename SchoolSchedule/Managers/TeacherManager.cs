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
    public class TeacherManager
    {
        private readonly TeacherDapper _teacherDapper;


        public TeacherManager()
        {
            _teacherDapper = new TeacherDapper();
        }



        public IEnumerable<Models.Teacher> GetTeacher()
        {


            {
                var teacher = _teacherDapper.GetTeacher();

                return teacher;
            }
        }


        public Models.Teacher GetOneTeacher(int Id)
        {
            {
                var teacher = _teacherDapper.GetOneTeacher(Id);

                return teacher;
            }


        }

        public void AddNew(Teacher teacher)
        {
            _teacherDapper.AddNew(teacher);
        }

        public void Update(Teacher teacher)
        {
            _teacherDapper.Update(teacher);
        }

        public void Delete(int id)
        {
            _teacherDapper.Delete(id);
        }

    }
}

