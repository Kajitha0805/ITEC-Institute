using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class FollowUpRepository:IFollowUpRepository
    {

        private readonly string _connectionString;

        public FollowUpRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<FollowUp>CreateFollowUp(FollowUp followUp)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO FollowUp(Name,Moblie,CourseId,Date,Email,Address,Description)VALUES(@Name,@Moblie,@CourseId,@Date,@Email,@Address,@Description)", connection);
                command.Parameters.AddWithValue("@Name", followUp.Name);
                command.Parameters.AddWithValue("@Moblie", followUp.Moblie);
                command.Parameters.AddWithValue("@CourseId", followUp.CourseId);
                command.Parameters.AddWithValue("@Date", followUp.Date);
                command.Parameters.AddWithValue("@Email", followUp.Email);
                command.Parameters.AddWithValue("@Address",followUp.Address);
                command.Parameters.AddWithValue("@Description", followUp.Description);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

            }
            return followUp;
        }
        public async Task<FollowUp> GetFollowUpById(string Name)
        {
            FollowUp followUp = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM FollowUp WHERE Name=@Name", connection);
                command.Parameters.AddWithValue("@Name", Name);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        followUp = new FollowUp()
                        {
                            Name = reader.GetString(0),
                            Moblie = reader.GetString(1),
                            CourseId = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Address = reader.GetString(5),
                            Description = reader.GetString(6)
                        };


                    }
                }
                return followUp;
            }
        }

        public async Task<FollowUp> DeleteFollowUpById(string Name)
        {
            FollowUp followUp = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM FollowUp WHERE Name=@Name", connection);
                command.Parameters.AddWithValue("@Name", Name);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        followUp = new FollowUp()
                        {
                            Name = reader.GetString(0),
                            Moblie = reader.GetString(1),
                            CourseId = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Address = reader.GetString(5),
                            Description = reader.GetString(6)
                        };

                    }
                }
                if (followUp != null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM FollowUp WHERE Name=@Name", connection);
                    deleteCommand.Parameters.AddWithValue("@Name", Name);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return followUp;
        }

        public async Task<List<FollowUp>> GetAllFollowUp()
        {
            var followUps = new List<FollowUp>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from FollowUp", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        followUps.Add(new FollowUp
                        {
                            Name = reader.GetString(0),
                            Moblie = reader.GetString(1),
                            CourseId = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Address = reader.GetString(5),
                            Description = reader.GetString(6)

                        });

                    }
                }
                return followUps;
            }
        }


    }
}
