using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;
using System.Numerics;
using System.Security.Cryptography;

namespace a_zApi.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly string _connectionString;
        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Student>CreateStudent(Student student)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Student(NicNo,FirstName,LastName,BOD,NicNumber,Age,Gender,TelNumber)VALUES(@StudentId,@FirstName,@LastName,@BOD,@NicNumber,@Age,@Gender,@TelNumber)", connection);
                command.Parameters.AddWithValue("@StudentId", Guid.NewGuid());
                command.Parameters.AddWithValue("@FirstName",student.FirstName);
                command.Parameters.AddWithValue("@LastName",student.LastName);
                command.Parameters.AddWithValue("@BOD",student.BOD);
                command.Parameters.AddWithValue("@NicNumber", student.NicNumber);
                command.Parameters.AddWithValue("@Age",student.Age);
                command.Parameters.AddWithValue("@Gender",student.Gender);
                command.Parameters.AddWithValue("@TelNumber", student.TelNumber);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            return student;
        }

        public async Task<List<Student>>GetAllStudent()
        {
            var students = new List<Student>(); 
            using( var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Student",connection);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentId=reader.GetGuid(0),
                            FirstName=reader.GetString(1),
                            LastName=reader.GetString(2),
                            BOD=reader.GetDateTime(3),
                            NicNumber=reader.GetString(4),
                            Age=reader.GetInt32(5),
                            Gender=reader.GetString(6),
                            TelNumber=reader.GetString(7),

                        });
                    }
                }
                return students;
            }
        }
        public async Task<Student> GetStudentById(Guid StudentId)
        {
            Student student=null;
            using( var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE StudentId=@StudentId",connection);
                command.Parameters.AddWithValue("StudentId", StudentId);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if(await reader.ReadAsync())
                    {
                        student=new Student
                        {
                            StudentId=reader.GetGuid(0),
                            FirstName=reader.GetString(1),
                            LastName=reader.GetString(2),
                            BOD=reader.GetDateTime(3),
                            NicNumber=reader.GetString(4),
                            Age=reader.GetInt32(5),
                            Gender=reader.GetString(6),
                            TelNumber=reader.GetString(7),

                        };

                    }
                }
                return student;
            }
        }
        public async Task<Student>DeleteStudentById(Guid StudentId)
        {
            Student student=null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE StudentId=@StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        student = new Student
                        {
                            StudentId = reader.GetGuid(0),
                            FirstName=reader.GetString(1),
                            LastName=reader.GetString(2),
                            BOD=reader.GetDateTime(3),
                            NicNumber=reader.GetString(4),
                            Age=reader.GetInt32(5),
                            Gender=reader.GetString(6),
                            TelNumber=reader.GetString(7),
                        };

                    }
                }
                if(student!=null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM Student WHERE StudentId=@StudentId", connection);
                    deleteCommand.Parameters.AddWithValue("@StudentId", StudentId);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return student;
        }
        public async Task<Student> FindStudentById(Guid StudentId)
        {
            Student student = null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE StudentId=@StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        student = new Student
                        {
                            StudentId = reader.GetGuid(0),
                            FirstName=reader.GetString(1),
                            LastName=reader.GetString(2),
                            BOD=reader.GetDateTime(3),
                            NicNumber=reader.GetString(4),
                            Age=reader.GetInt32(5),
                            Gender=reader.GetString(6),
                            TelNumber=reader.GetString(7)
                        };

                    }
                }
                return student;
            }
        }
        public async Task<Student>UpdateStudent(Student student)
        {
            Student updateStudent = null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Student SET StudentId = @StudentId, FirstName = @FirstName, LastName = @LastName,BOD=@BOD,NicNumber=@NicNumber,Age=@Age,Gender=@Gender,TelNumber=@TelNumber WHERE StudentId = @StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", student.StudentId);
                command.Parameters.AddWithValue("FirstName",student.FirstName);
                command.Parameters.AddWithValue("LastName",student.LastName);
                command.Parameters.AddWithValue("BOD",student.BOD);
                command.Parameters.AddWithValue("NicNumber",student.NicNumber);
                command.Parameters.AddWithValue("Age",student.Age);
                command.Parameters.AddWithValue("Gender",student.Gender);
                command.Parameters.AddWithValue("TelNumber",student.TelNumber);

                await connection.OpenAsync();

                var affectedRows=await command.ExecuteNonQueryAsync();
                if(affectedRows>0)
                {
                    updateStudent=student;
                }

            }
            return updateStudent;
        }

    }
}
