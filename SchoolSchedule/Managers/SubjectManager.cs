using Dapper;
using SchoolSchedule.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace SchoolSchedule.Managers
{
    public class SubjectManager
    {
        private readonly string connectionString;

        public SubjectManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public List<Subject> GetAllSubjects()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Subject>("SELECT * FROM Subject").ToList();
            }
        }

        // Другие методы для работы с таблицей Subjects
    }
}