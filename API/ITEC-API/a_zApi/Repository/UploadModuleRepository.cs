using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class UploadModuleRepository:IUploadModuleRepository
    {
        private readonly string _connectionString;

        public UploadModuleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<UploadModule> CreateUploadModule(UploadModule uploadModule)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO UploadModule(Title,CourseId,Batch,Date,Uplode,Description)VALUES(@Title,@CourseId,@Batch,@Date,@Uplode,@Description)", connection);
                command.Parameters.AddWithValue("@Title", uploadModule.Title);
                command.Parameters.AddWithValue("@CourseId", uploadModule.CourseId);
                command.Parameters.AddWithValue("@Batch", uploadModule.Batch);
                command.Parameters.AddWithValue("@Date", uploadModule.Date);
                command.Parameters.AddWithValue("@Uplode", uploadModule.Uplode);
                command.Parameters.AddWithValue("@Description", uploadModule.Description);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

            }
            return uploadModule;
        }
        public async Task<List<UploadModule>> GetAllUpModules()
        {
            var modules = new List<UploadModule>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from UploadModule", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        modules.Add(new UploadModule
                        {
                            Title = reader.GetString(0),
                            CourseId = reader.GetString(1),
                            Batch = reader.GetString(2),
                            Date = reader.GetDateTime(3),
                            Uplode = reader["Uplode"] as byte[],
                            Description = reader.GetString(5),
                          
                        });

                    }
                }
                return modules;
            }
        }
    }
    
}
