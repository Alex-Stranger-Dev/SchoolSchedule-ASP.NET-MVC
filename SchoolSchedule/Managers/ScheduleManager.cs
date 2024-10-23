using Dapper;
using SchoolSchedule.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;


namespace SchoolSchedule.Managers
{
    public class ScheduleManager
    {
        private readonly string connectionString;

        public ScheduleManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public List<Schedule> GetSchedule()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT s.Name AS StudentName, s.LastName AS StudentLastName, sub.Name AS Subject, t.LastName AS TeacherLastName
                    FROM Student s
                    JOIN Subject sub ON s.Class = sub.Class
                    JOIN Teacher t ON sub.Name = t.Subject";

                return connection.Query<Schedule>(query).ToList();
            }
        }

        // Другие методы для работы с таблицей Schedule
    }
}