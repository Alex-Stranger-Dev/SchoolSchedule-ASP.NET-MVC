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
        private readonly SubjectDapper _subjectDapper;

        public SubjectManager()
        {
            _subjectDapper = new SubjectDapper();
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

        public void AddNewSubject(Subject subject)
        {
            _subjectDapper.AddNewSubject(subject);
        }


        public void UpdateSubject(Subject subject)
        {
            _subjectDapper.UpdateSubject(subject);
        }

        public void DeleteSubject(int id)
        {
            _subjectDapper.DeleteSubject(id);
        }

    }
}

