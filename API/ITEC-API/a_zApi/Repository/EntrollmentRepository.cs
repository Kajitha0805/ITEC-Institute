using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class EntrollmentRepository: IEntrollmentRepository
    {
        private readonly string _connectionString;
        public EntrollmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Entrollment> CreateEntrollment(Entrollment entrollment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Entrollment(EntrollmentID,NicNo,CourseId)VALUES(@EntrollmentID,@NicNo,@CourseId)", connection);
                command.Parameters.AddWithValue("@EntrollmentID", entrollment.EntrollmentID);
                command.Parameters.AddWithValue("@NicNo", entrollment.NicNo);
                command.Parameters.AddWithValue("@CourseId", entrollment.CourseId);
               
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            return entrollment;
        }
        public async Task<List<Entrollment>> GetAllentrollment()
        {
            var entrollments = new List<Entrollment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Entrollment", connection);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        entrollments.Add(new Entrollment
                        {
                            EntrollmentID = reader.GetString(0),
                            NicNo = reader.GetString(1),
                            CourseId = reader.GetString(2),

                        });
                    }
                }
                return entrollments;
            }

        }
        public async Task<Entrollment> GetEntrollment(string NicNo)
        {
            Entrollment Entrollment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Entrollment WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("NicNo", NicNo);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        Entrollment = new Entrollment
                        {
                            EntrollmentID = reader.GetString(0),
                            NicNo = reader.GetString(1),
                            CourseId = reader.GetString(2),
                          

                        };

                    }
                }
                return Entrollment;
            }
        }
        public async Task<Entrollment> DeleteEntrollment(string NicNo)
        {
            Entrollment Entrollment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Entrollment WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("@NicNo", NicNo);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        Entrollment = new Entrollment
                        {
                            EntrollmentID = reader.GetString(0),
                            NicNo = reader.GetString(1),
                            CourseId = reader.GetString(2),
                        };

                    }
                }
                if (Entrollment != null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM Entrollment WHERE NicNo=@NicNo", connection);
                    deleteCommand.Parameters.AddWithValue("@NicNo", NicNo);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return Entrollment;
        }
        public async Task<Entrollment> FindEntrollment(string NicNo)
        {
            Entrollment Entrollment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Entrollment WHERE NicNo=@NicNo", connection);
                command.Parameters.AddWithValue("@NicNo", NicNo);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        Entrollment = new Entrollment
                        {
                            EntrollmentID = reader.GetString(0),
                            NicNo = reader.GetString(1),
                            CourseId = reader.GetString(2),
                        };

                    }
                }
                return Entrollment;
            }
        }
        public async Task<Entrollment> UpdateEntrollment(Entrollment Entrollment)
        {
            Entrollment updateEntrollment = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Entrollment(EntrollmentID,NicNo,CourseId)VALUES(@EntrollmentID,@NicNo,@CourseId)", connection);
                command.Parameters.AddWithValue("@EntrollmentID", Entrollment.EntrollmentID);
                command.Parameters.AddWithValue("@NicNo", Entrollment.NicNo);
                command.Parameters.AddWithValue("@CourseId", Entrollment.CourseId);

                await connection.OpenAsync();

                var affectedRows = await command.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    updateEntrollment = Entrollment;
                }

            }
            return updateEntrollment;
        }

    }
}
