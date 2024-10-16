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
    }
}
