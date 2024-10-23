using Dapper;
using SchoolSchedule.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace SchoolSchedule.Managers
{
    public class TeacherManager
    {
        private readonly string connectionString;

        public TeacherManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public List<Teacher> GetAllTeachers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Teacher>("SELECT * FROM Teacher").ToList();
            }
        }

        // Другие методы для работы с таблицей Teachers
    }
}