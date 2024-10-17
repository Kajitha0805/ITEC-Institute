using a_zApi.Enitity;

namespace a_zApi.IRepository
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateExpense(Expense expense);
        Task<List<Expense>> GetAllExpense();
    }
}
