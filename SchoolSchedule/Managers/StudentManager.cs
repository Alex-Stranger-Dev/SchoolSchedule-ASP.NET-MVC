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
    public class StudentManager
    {
        private readonly StudentDapper _studentDapper;


        public StudentManager()
        {
            _studentDapper = new StudentDapper();
        }



        public IEnumerable<Models.Student> GetStudent()
        {


            {
                var student = _studentDapper.GetStudent();

                return student;
            }
        }


        public Models.Student GetOneStudent(int id)
        {
            {
                var student = _studentDapper.GetOneStudent(id);

                return student;
            }


        }

        
    }
}

