using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using Dapper;
using SchoolSchedule.Models;
using System.Xml.Linq;

namespace SchoolSchedule.Data
{
    public class TeacherDapper
    {
        private readonly string connectionString;

        public TeacherDapper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        public List<Models.Teacher> GetTeacher()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT t.Id AS Id,sub.Name AS Subject, t.LastName AS TeacherLastName, t.Name AS Name
                    FROM Teacher t
                    JOIN Subject sub ON s.Class = sub.Class";


                return connection.Query<Teacher>(query).ToList();
            }
        }

        public Models.Teacher GetOneTeacher(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT t.Id AS Id,sub.Name AS Subject, t.LastName AS TeacherLastName, t.Name AS Name
                    FROM Teacher t
                    JOIN Subject sub ON s.Class = sub.Class
                    WHERE t.Id = @Id";

                return connection.QuerySingleOrDefault<Teacher>(query, new { Id });
            }

        }

    }
}



//{
//    public class RoomsDapper
//    {
//        private readonly string _connectionString;

//        public RoomsDapper()
//        {
//            _connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
//        }

//        public IEnumerable<HotelSystem.Models.Rooms> GetAllRooms()
//        {
//            using (IDbConnection db = new SqlConnection(_connectionString))
//            {
//                string sqlQuery = "EXEC Rooms_GetDataAll";
//                var data = db.Query<HotelSystem.Models.Rooms>(sqlQuery);
//                return data;
//            }
//        }

//        public HotelSystem.Models.Rooms GetRoom(int Id)
//        {
//            using (IDbConnection db = new SqlConnection(_connectionString))
//            {
//                string sqlQuery = "EXEC Rooms_GetData @Id";
//                var data = db.Query<HotelSystem.Models.Rooms>(sqlQuery, new
//                {
//                    Id = Id
//                }).FirstOrDefault();
//                return data;
//            }
//        }

//        public bool RoomsUpdate(Models.Rooms data)
//        {
//            using (IDbConnection db = new SqlConnection(_connectionString))
//            {
//                try
//                {
//                    string sqlQuery = "EXEC Rooms_Update @Id, @RoomNumber, @RoomType, @PricePerNigth, @Status, @Note";

//                    db.Execute(sqlQuery, new
//                    {
//                        Id = data.Id,
//                        RoomNumber = data.RoomNumber,
//                        RoomType = data.RoomType,
//                        PricePerNigth = data.PricePerNigth,
//                        Status = data.Status,
//                        Note = data.Note,
//                    });
//                    return true;

//                }
//                catch (Exception ex)
//                {
//                    return false;
//                }
//            }
//        }

//        public bool Insert(Models.Rooms data)
//        {
//            //var formattedDate = data.DateOfBirth.ToString("yyyy-MM-dd");

//            using (IDbConnection db = new SqlConnection(_connectionString))
//            {
//                try
//                {
//                    string sqlQuery = "EXEC Rooms_Insert @RoomNumber, @RoomType, @PricePerNigth, @Status, @Note";
//                    db.Execute(sqlQuery, new
//                    {
//                        RoomNumber = data.RoomNumber,
//                        RoomType = data.RoomType,
//                        PricePerNigth = data.PricePerNigth,
//                        Status = data.Status,
//                        Note = data.Note,
//                    });
//                    return true;

//                }
//                catch (Exception ex)
//                {
//                    return false;
//                }
//            }
//        }

//        public bool Delete(int Id)
//        {
//            using (IDbConnection db = new SqlConnection(_connectionString))
//            {
//                try
//                {
//                    string sqlQuery = "EXEC Rooms_Delete @Id";
//                    db.Execute(sqlQuery, new
//                    {
//                        Id = Id,
//                    });

//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    return false;
//                }
//            }
//        }
//    }
//}