using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.Enitity;
using a_zApi.IRepository;
using a_zApi.IServices;
using a_zApi.Repository;

namespace a_zApi.Services
{
    public class ExpenseService:IExpenseService
    {
        private readonly IExpenseRepository _iexpenseRepository;
        public ExpenseService(IExpenseRepository iexpenseRepository)
        {
            _iexpenseRepository = iexpenseRepository;
        }
        public async Task<ExpenseResponse> CreateExpense(ExpenseRequest expenseRequest)
        {
            var inputExpense= new Expense();
            inputExpense.Title = expenseRequest.Title;
            inputExpense.Date = expenseRequest.Date;
            inputExpense.Price = expenseRequest.Price;
            if (expenseRequest.Receipt != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await expenseRequest.Receipt.CopyToAsync(memoryStream);
                    inputExpense.Receipt = memoryStream.ToArray();
                }
            };
            inputExpense.Description = expenseRequest.Description;

            var addedExpenses = await _iexpenseRepository.CreateExpense(inputExpense);

            var response = new ExpenseResponse();
            response.Title = addedExpenses.Title;
            response.Date = addedExpenses.Date;
            response.Price = addedExpenses.Price;
            response.Receipt = addedExpenses.Receipt;
            response.Description = addedExpenses.Description;

            return response;

        }
        public async Task<List<ExpenseResponse>> GetAllExpenses()
        {
            var data = await _iexpenseRepository.GetAllExpense();
            var response = new List<ExpenseResponse>();
            foreach (var ex in data)
            {
                var expenseResponse = new ExpenseResponse();
                expenseResponse.Title = ex.Title;
                expenseResponse.Date = ex.Date;
                expenseResponse.Price = ex.Price;
                expenseResponse.Receipt = ex.Receipt;
                expenseResponse.Description = ex.Description;
                response.Add(expenseResponse);
            }
            return response;
        }
    }
}
