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
using SchoolSchedule.Abstract;


namespace SchoolSchedule.Managers
{
    public class SubjectManager
    {
        private readonly ISubjectDapper _subjectDapper;


        //public SubjectManager()
        //{
        //    _subjectDapper = new SubjectDapper();
        //}

        public SubjectManager(ISubjectDapper dapper)
        {
            _subjectDapper = dapper;
        }

        public IEnumerable<Models.Subject> GetListSubject()
        {
            {
                var subject = _subjectDapper.GetListSubject();

                return subject;
            }
        }

        public Models.Subject GetOneSubject(int Id) 
        {
            {
                var subject = _subjectDapper.GetOneSubject(Id);

                return subject;
            }

        }
       
    }
}

