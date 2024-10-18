using System.Data;
using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class FeeRepository: lFeeRepository
    {
        private readonly string _connectionString;
        public FeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Fee> CreateFee(Fee fee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Fee(StudentId,Name,MobileNo,Dueamount,Payamount)VALUES(@StudentId,@Name,@MobileNo,@Dueamount,@Payamount)", connection);
                command.Parameters.AddWithValue("@StudentId", fee.StudentId);
                command.Parameters.AddWithValue("@Name", fee.Name);
                command.Parameters.AddWithValue("@MobileNo", fee.MobileNo);
                command.Parameters.AddWithValue("@Dueamount", fee.Dueamount);
                command.Parameters.AddWithValue("@Payamount", fee.Payamount);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            return fee;
        }
        public async Task<List<Fee>> GetAllFee()
        {
            var fees = new List<Fee>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Fee", connection);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        fees.Add(new Fee
                        {
                            StudentId = reader.GetString(0),
                            Name = reader.GetString(1),
                            MobileNo = reader.GetString(2),
                            Dueamount = reader.GetDecimal(3),
                            Payamount = reader.GetDecimal(10),

                        });
                    }
                }
                return fees;
            }
        }
        public async Task<Fee> GetFeeById(string StudentId)
        {
            Fee fee = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Fee WHERE StudentId=@StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        fee = new Fee
                        {
                            StudentId = reader.GetString(0),
                            Name = reader.GetString(1),
                            MobileNo = reader.GetString(2),
                            Dueamount = reader.GetDecimal(3),
                            Payamount = reader.GetDecimal(4),
                          
                        };

                    }
                }
                return fee;
            }
        }
        public async Task<Fee> DeleteFeeById(string StudentId)
        {
            Fee fee = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Fee WHERE StudentId=@StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        fee = new Fee
                        {
                            StudentId = reader.GetString(0),
                            Name = reader.GetString(1),
                            MobileNo = reader.GetString(2),
                            Dueamount = reader.GetDecimal(3),
                            Payamount = reader.GetDecimal(4),

                        };

                    }
                }
                if (fee != null)
                {
                    var deleteCommand = new SqlCommand("DELETE FROM Fee WHERE StudentId=@StudentId", connection);
                    deleteCommand.Parameters.AddWithValue("@StudentId", StudentId);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

            }
            return fee;
        }
        public async Task<Fee> FindFeeById(string StudentId)
        {
            Fee fee = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Fee WHERE StudentId=@StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", StudentId);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        fee = new Fee
                        {
                            StudentId = reader.GetString(0),
                            Name = reader.GetString(1),
                            MobileNo = reader.GetString(2),
                            Dueamount = reader.GetDecimal(3),
                            Payamount = reader.GetDecimal(4),
                        };

                    }
                }
                return fee;
            }
        }
        public async Task<Fee> UpdateFee(Fee fee)
        {
            Fee updateFee = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Fee SET StudentId =@StudentId, Name = @Name, MobileNo = @MobileNo,Dueamount=@Dueamount,Payamount=@Payamount WHERE StudentId = @StudentId", connection);
                command.Parameters.AddWithValue("@StudentId", fee.StudentId);
                command.Parameters.AddWithValue("@Name", fee.Name);
                command.Parameters.AddWithValue("@MobileNo", fee.MobileNo);
                command.Parameters.AddWithValue("@Dueamount", fee.Dueamount);
                command.Parameters.AddWithValue("@Payamount", fee.Payamount);
       
                await connection.OpenAsync();

                var affectedRows = await command.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    updateFee = fee;
                }

            }
            return updateFee;
        }

    }
}
