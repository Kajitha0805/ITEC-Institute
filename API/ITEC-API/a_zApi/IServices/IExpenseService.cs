using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;

namespace a_zApi.IServices
{
    public interface IExpenseService
    {
        Task<ExpenseResponse> CreateExpense(ExpenseRequest expenseRequest);
        Task<List<ExpenseResponse>> GetAllExpenses();
    }
}
