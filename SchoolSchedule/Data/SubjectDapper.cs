using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using SchoolSchedule.Models;


namespace SchoolSchedule.Data
{
    public class SubjectDapper
    {
        private readonly string _connectionString;

        public SubjectDapper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["AlexDbConnection"].ConnectionString;
        }

        //public List<Models.Subject> GetListSubject()
        //{
        //   try
        //    {
        //        using (var connection = new SqlConnection(_connectionString))
        //        {
        //            var query = @"
        //                SELECT s.Id, s.Name, s.Class
        //                FROM Subject s
        //                JOIN Teacher t ON s.Name = t.Subject";

        //            return connection.Query<Subject>(query).ToList();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<Subject>(); //вернуться и подумать что вернуть
        //    }

        //}


        public List<Models.Subject> GetListSubject()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = @"
                SELECT Id, Name, Class
                FROM Subject";

                    return connection.Query<Subject>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return new List<Subject>();
            }
        }


        //public Models.Subject GetOneSubject(int Id)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var query = @"
        //            SELECT  s.Id, s.Name, s.Class, t.LastName
        //            FROM Subject s
        //            JOIN Teacher t ON s.Name = t.Subject
        //            WHERE s.Id = @Id";

        //        return connection.QuerySingleOrDefault<Subject>(query, new { Id });
        //    }

        //}


        public Models.Subject GetOneSubject(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
            SELECT s.Id, s.Name, s.Class
            FROM Subject s
            WHERE s.Id = @Id";

                return connection.QuerySingleOrDefault<Subject>(query, new { Id });
            }
        }


        public void AddNewSubject(Subject subject)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
            INSERT INTO Subject (Name, Class)
            VALUES (@Name, @Class);
            SELECT CAST(SCOPE_IDENTITY() as int)";

                var id = connection.QuerySingle<int>(query, new { subject.Name, subject.Class });
                subject.Id = id;
            }
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
            UPDATE Subject
            SET Name = @Name, Class = @Class
            WHERE Id = @Id";

                connection.Execute(query, new { subject.Name, subject.Class, subject.Id });
            }
        }

        public void DeleteSubject(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"
            DELETE FROM Subject
            WHERE Id = @Id";

                connection.Execute(query, new { Id = id });
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