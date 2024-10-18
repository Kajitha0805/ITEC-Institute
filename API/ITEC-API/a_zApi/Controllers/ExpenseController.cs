using a_zApi.DTO.RequestDto;
using a_zApi.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _iexpenseService;
        public ExpenseController(IExpenseService iexpenseService)
        {
            _iexpenseService = iexpenseService;
        }
        [HttpPost("Create_Expense")]
        public async Task<IActionResult> CreateExpense(ExpenseRequest expenseRequest)
        {
            var data=await _iexpenseService.CreateExpense(expenseRequest);
            return Ok(data);
        }
        [HttpGet("Get_All_Expense")]
        public async Task<IActionResult>GetAllExpense()
        {
            var data=await _iexpenseService.GetAllExpenses();
            return Ok(data);
        }
    }
}
