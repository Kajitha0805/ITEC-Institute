using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class StudentRegisterRepository: IStudentRegisterRepository

    {
        private readonly string _connectionString;

        public StudentRegisterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddStudentRegister(StudentRegister studentRegister)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO StudentRegister (NICNo, FirstName, LastName, MobileNo, EmailId, Address, Password) " +
                               "VALUES (@NICNo, @FirstName, @LastName, @MobileNo, @EmailId, @Address, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NICNo", studentRegister.NICNo);
                    command.Parameters.AddWithValue("@FirstName", studentRegister.FirstName);
                    command.Parameters.AddWithValue("@LastName", studentRegister.LastName);
                    command.Parameters.AddWithValue("@MobileNo", studentRegister.MobileNo);
                    command.Parameters.AddWithValue("@EmailId", studentRegister.EmailId);
                    command.Parameters.AddWithValue("@Address", studentRegister.Address);
                    command.Parameters.AddWithValue("@Password", studentRegister.Password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }




        public StudentRegister GetStudentRegisterByNIC(string nicNo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM StudentRegister WHERE NICNo = @NICNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NICNo", nicNo);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new StudentRegister
                            {
                                NICNo = reader["NICNo"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                MobileNo = Convert.ToInt32(reader["MobileNo"]),
                                EmailId = reader["EmailId"].ToString(),
                                Address = reader["Address"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }


        public IEnumerable<StudentRegister> GetAllStudentRegister()
        {
            var studentRegister = new List<StudentRegister>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM StudentRegister";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentRegister.Add(new StudentRegister
                            {
                                NICNo = reader["NICNo"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                MobileNo = Convert.ToInt32(reader["MobileNo"]),
                                EmailId = reader["EmailId"].ToString(),
                                Address = reader["Address"].ToString(),
                                Password = reader["Password"].ToString()
                            });
                        }
                    }
                }
            }

            return studentRegister;
        }



        public void UpdateStudentRegister(StudentRegister studentRegister)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE StudentRegister SET FirstName = @FirstName, LastName = @LastName, MobileNo = @MobileNo, " +
                               "EmailId = @EmailId, Address = @Address, Password = @Password WHERE NICNo = @NICNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NICNo", studentRegister.NICNo);
                    command.Parameters.AddWithValue("@FirstName", studentRegister.FirstName);
                    command.Parameters.AddWithValue("@LastName", studentRegister.LastName);
                    command.Parameters.AddWithValue("@MobileNo", studentRegister.MobileNo);
                    command.Parameters.AddWithValue("@EmailId", studentRegister.EmailId);
                    command.Parameters.AddWithValue("@Address", studentRegister.Address);
                    command.Parameters.AddWithValue("@Password", studentRegister.Password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteStudentRegister(string nicNo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM StudentRegister WHERE NICNo = @NICNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NICNo", nicNo);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

