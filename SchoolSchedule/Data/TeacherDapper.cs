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
                    SELECT  DISTINCT t.Id, t.LastName, t.Name, t.Subject
                    FROM Teacher t
                    JOIN Subject sub ON Class = sub.Class";


                return connection.Query<Teacher>(query).ToList();
            }
        }

        public Models.Teacher GetOneTeacher(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT  TOP 1 t.Id, t.LastName, t.Name, t.Subject
                    FROM Teacher t
                    JOIN Subject sub ON Class = sub.Class
                    WHERE t.Id = @Id";

                return connection.QuerySingleOrDefault<Teacher>(query, new { Id });
            }

        }

        public void AddNew(Teacher teacher)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @" 
                            INSERT INTO Teacher (Name, LastName, Subject)
                            VALUES (@Name, @LastName, @Subject); 
                            SELECT CAST(SCOPE_IDENTITY() as int)"; 
                var id = connection.QuerySingle<int>(query, new { teacher.Name, teacher.LastName, teacher.Subject }); teacher.Id = id;
            } 
        }

        public void Update(Teacher teacher)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
            UPDATE Teacher
            SET Name = @Name, LastName = @LastName, Subject = @Subject
            WHERE Id = @Id";

                connection.Execute(query, new { teacher.Name, teacher.LastName, teacher.Subject, teacher.Id });
            }
        }

        public void ReorderTeacherIds()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var tempTableQuery = @"
                CREATE TABLE #TempTeacher
                (
                    TempId INT IDENTITY(1,1),
                    Name NVARCHAR(MAX),
                    LastName NVARCHAR(MAX),
                    Subject NVARCHAR(MAX)
                );

                INSERT INTO #TempTeacher (Name, LastName, Subject)
                SELECT Name, LastName, Subject FROM Teacher ORDER BY Id;

                DELETE FROM Teacher;

                DBCC CHECKIDENT ('Teacher', RESEED, 0);

                INSERT INTO Teacher (Name, LastName, Subject)
                SELECT Name, LastName, Subject FROM #TempTeacher;

                DROP TABLE #TempTeacher";

                    connection.Execute(tempTableQuery, transaction: transaction);
                    transaction.Commit();
                }
            }
        }






        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
            DELETE FROM Teacher
            WHERE Id = @Id";

                connection.Execute(query, new { Id = id });
                ReorderTeacherIds();
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