using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class BatchRepository:IBatchRepository
    {
        private readonly string _connectionString;
        public BatchRepository(string connectionString)
        {
            _connectionString = connectionString;

        }
        public async Task<Batch> CreateBatch(Batch batch)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Batch(BatchName)VALUES(@BatchName)", connection);
                //command.Parameters.AddWithValue("@BatchId", batch.BatchId);
                command.Parameters.AddWithValue("@BatchName", batch.BatchName);
               
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

            }
            return batch;
        }
        public async Task<List<Batch>> GetAllBatch()
        {
            var batches = new List<Batch>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Batch", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        batches.Add(new Batch
                        {
                            //BatchId = reader.GetGuid(0),
                            BatchName = reader.GetString(0),
                            
                        });

                    }
                }
                return batches;
            }
        }
    }
}
