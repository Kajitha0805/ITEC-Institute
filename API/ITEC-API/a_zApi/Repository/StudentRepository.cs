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
                var command = new SqlCommand("INSERT INTO Student(NicNo,FirstName,LastName,CourseId,Date,Batch,MobileNo,Email,Address,RegFee,AdditionalFee)VALUES(@NicNo,@FirstName,@LastName,@CourseId,@Date,@Batch,@MobileNo,@Email,@Address,@RegFee,@AdditionalFee)", connection);
                command.Parameters.AddWithValue("@NicNo", student.NicNo);
                command.Parameters.AddWithValue("@FirstName",student.FirstName);
                command.Parameters.AddWithValue("@LastName",student.LastName);
                command.Parameters.AddWithValue("@CourseId", student.CourseId);
                command.Parameters.AddWithValue("@Batch", student.Batch);
                command.Parameters.AddWithValue("@Date", student.Date);
                command.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Address",student.Address);
                command.Parameters.AddWithValue("@RegFee",student.RegFee);
                command.Parameters.AddWithValue("@AdditionalFee",student.AdditionalFee);

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
                            NicNo=reader.GetString(0),
                            FirstName=reader.GetString(1),
                            LastName=reader.GetString(2),
                            CourseId=reader.GetString(3),
                            Batch=reader.GetString(4),
                            Date=reader.GetDateTime(5),
                            MobileNo=reader.GetString(6),
                            Email=reader.GetString(7),
                            Address=reader.GetString(8),
                            RegFee=reader.GetDecimal(9),
                            AdditionalFee=reader.GetDecimal(10),

                        });
                    }
                }
                return students;
            }
        }
        public async Task<Student> GetStudentById(string NicNo)
        {
            Student student=null;
            using( var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("NicNo", NicNo);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if(await reader.ReadAsync())
                    {
                        student=new Student
                        {
                            NicNo = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            CourseId = reader.GetString(3),
                            Batch = reader.GetString(4),
                            Date = reader.GetDateTime(5),
                            MobileNo = reader.GetString(6),
                            Email = reader.GetString(7),
                            Address = reader.GetString(8),
                            RegFee = reader.GetDecimal(9),
                            AdditionalFee = reader.GetDecimal(10),

                        };

                    }
                }
                return student;
            }
        }
        public async Task<Student>DeleteStudentById(string NicNo)
        {
            Student student=null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("@NicNo", NicNo);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        student = new Student
                        {
                            NicNo = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            CourseId = reader.GetString(3),
                            Batch = reader.GetString(4),
                            Date = reader.GetDateTime(5),
                            MobileNo = reader.GetString(6),
                            Email = reader.GetString(7),
                            Address = reader.GetString(8),
                            RegFee = reader.GetDecimal(9),
                            AdditionalFee = reader.GetDecimal(10),
                        };

                    }
                }
                if(student!=null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM Student WHERE NicNo=@NicNo", connection);
                    deleteCommand.Parameters.AddWithValue("@NicNo", NicNo);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return student;
        }
        public async Task<Student> FindStudentById(string NicNo)
        {
            Student student = null;
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Student WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("@NicNo", NicNo);
                await connection.OpenAsync();
                using(var reader=await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        student = new Student
                        {
                            NicNo = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            CourseId = reader.GetString(3),
                            Batch = reader.GetString(4),
                            Date = reader.GetDateTime(5),
                            MobileNo = reader.GetString(6),
                            Email = reader.GetString(7),
                            Address = reader.GetString(8),
                            RegFee = reader.GetDecimal(9),
                            AdditionalFee = reader.GetDecimal(10),
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
                var command = new SqlCommand("UPDATE Student SET NicNo =@NicNo, FirstName = @FirstName, LastName = @LastName,CourseId=@CourseId,Batch=@Batch,Date=@Date,MobileNo=@MobileNo,Email=@Email,Address=@Address,RegFee=@RegFee,AdditionalFee=@AdditionalFee WHERE NicNo = @NicNo", connection);
                command.Parameters.AddWithValue("@NicNo", student.NicNo);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);
                command.Parameters.AddWithValue("@CourseId", student.CourseId);
                command.Parameters.AddWithValue("@Batch", student.Batch);
                command.Parameters.AddWithValue("@Date", student.Date);
                command.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@RegFee", student.RegFee);
                command.Parameters.AddWithValue("@AdditionalFee", student.AdditionalFee);

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
