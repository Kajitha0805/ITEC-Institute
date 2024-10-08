﻿using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly string _connectionString;
        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Course>CreateCourse(Course course)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Course(CourseId,CourseName,Duration,Fee,Instructor,Syllabus)VALUES(@CourseId,@CourseName,@Duration,@Fee,@Instructor,@Syllabus)", connection);
                command.Parameters.AddWithValue("@CourseId", course.CourseId);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@Duration", course.Duration);
                command.Parameters.AddWithValue("@Fee", course.Fee);
                command.Parameters.AddWithValue("@Instructor", course.Instructor);
                command.Parameters.AddWithValue("@Syllabus", course.Syllabus);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

            }
            return course;
        }
        public async Task<List<Course>>GetAllCourse()
        {
            var courses = new List<Course>();
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Course", connection);
                await connection.OpenAsync();

                using(var reader=await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseId = reader.GetString(0),
                            CourseName = reader.GetString(1),
                            Duration = reader.GetString(2),
                            Fee = reader.GetDecimal(3),
                            Instructor = reader.GetString(4),
                            Syllabus = reader.GetString(5)

                        });

                    }
                }
                return courses;
            }
        }
        public async Task<Course> GetCourseById(string CourseId)
        {
            Course course=null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Course WHERE CourseId=@CourseId", connection);
                command.Parameters.AddWithValue("@CourseId", CourseId);
                await connection.OpenAsync();
                using(var reader= await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        course = new Course()
                        {
                            CourseId = reader.GetString(0),
                            CourseName = reader.GetString(1),
                            Duration = reader.GetString(2),
                            Fee = reader.GetDecimal(3),
                            Instructor = reader.GetString(4),
                            Syllabus = reader.GetString(5)
                        };


                    }
                }
                return course;
            }
        }
        public async Task<Course> DeleteCourseById(string CourseId)
        {
            Course course = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Course WHERE CourseId=@CourseId", connection);
                command.Parameters.AddWithValue("@CourseId", CourseId);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        course = new Course
                        {
                            CourseId = reader.GetString(0),
                            CourseName = reader.GetString(1),
                            Duration = reader.GetString(2),
                            Fee = reader.GetDecimal(3),
                            Instructor = reader.GetString(4),
                            Syllabus = reader.GetString(5)
                        };

                    }
                }
                if (course != null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM Course WHERE CourseId=@CourseId", connection);
                    deleteCommand.Parameters.AddWithValue("@CourseId", CourseId);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return course;
        }

        public async Task<Course> FindCourseById(string CourseId)
        {
            Course course = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Course WHERE CourseId=@CourseId", connection);
                command.Parameters.AddWithValue("@CourseId", CourseId);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        course = new Course
                        {
                            CourseId = reader.GetString(0),
                            CourseName = reader.GetString(1),
                            Duration = reader.GetString(2),
                            Fee = reader.GetDecimal(3),
                            Instructor = reader.GetString(4),
                            Syllabus = reader.GetString(5)
                        };

                    }
                }
                return course;
            }
        }
        public async Task<Course>UpdateCourse(Course course)
        {
            Course updateCourse= null;    
            using(var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Course SET CourseId = @CourseId, CourseName = @CourseName, Duration = @Duration,Fee=@Fee,Instructor=@Instructor,Syllabus=@Syllabus WHERE CourseId = @CourseId", connection);
                command.Parameters.AddWithValue("@CourseId", course.CourseId);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);
                command.Parameters.AddWithValue("@Duration", course.Duration);
                command.Parameters.AddWithValue("@Fee", course.Fee);
                command.Parameters.AddWithValue("@Instructor", course.Instructor);
                command.Parameters.AddWithValue("@Syllabus", course.Syllabus);


                await connection.OpenAsync();
                var affectedRows= await command.ExecuteNonQueryAsync();
                if (affectedRows>0)
                {
                    updateCourse=course;
                }

            }
            return updateCourse;
           
        }

    }
}
