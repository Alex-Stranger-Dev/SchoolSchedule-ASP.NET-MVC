using Dapper;
using SchoolSchedule.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace SchoolSchedule.Managers
{
    public class StudentManager
    {
        private readonly string connectionString;

        public StudentManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public List<Student> GetAllStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Student>("SELECT * FROM Student").ToList();
            }
        }

        // Другие методы для работы с таблицей Students
    }
}