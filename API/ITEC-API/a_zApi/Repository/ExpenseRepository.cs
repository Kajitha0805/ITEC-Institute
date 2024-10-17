using a_zApi.Enitity;
using a_zApi.IRepository;
using Microsoft.Data.SqlClient;

namespace a_zApi.Repository
{
    public class ExpenseRepository:IExpenseRepository
    {
        private readonly string _connectionString;
        public ExpenseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Expense> CreateExpense(Expense expense)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Expense(Title,Date,Price,Receipt,Description)VALUES(@Title,@Date,@Price,@Receipt,@Description)", connection);
                command.Parameters.AddWithValue("@Title", expense.Title);
                command.Parameters.AddWithValue("@Date", expense.Date);
                command.Parameters.AddWithValue("@Price", expense.Price);
                command.Parameters.AddWithValue("@Receipt", expense.Receipt);
                command.Parameters.AddWithValue("@Description", expense.Description);
               

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

            }
            return expense;
        }
        public async Task<List<Expense>> GetAllExpense()
        {
            var expenses = new List<Expense>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("select * from Expense", connection);
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        expenses.Add(new Expense
                        {
                            Title = reader.GetString(0),
                            Date = reader.GetDateTime(1),
                            Price = reader.GetDecimal(2),
                            Receipt = reader["Receipt"] as byte[],
                            Description = reader.GetString(4),

                        });

                    }
                }
                return expenses;
            }
        }
    }
}
