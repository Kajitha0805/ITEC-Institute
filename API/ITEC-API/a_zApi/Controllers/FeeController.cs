using a_zApi.DTO.RequestDto;
using a_zApi.IServices;
using a_zApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        public readonly IFeeServices _ifeeServices;

        public FeeController(IFeeServices ifeeServices)
        {
            _ifeeServices = ifeeServices;
        }
        [HttpPost("Create_Fee")]
        public async Task<IActionResult> CreateProduct(FeeRequest FeeRequest)
        {
            var data = await _ifeeServices.CreateFee(FeeRequest);
            return Ok(data);
        }
        [HttpGet("Get_All_Fee")]
        public async Task<IActionResult> GetAllFee()
        {
            var data = await _ifeeServices.GetAllFee();
            return Ok(data);
        }
        [HttpGet("Get_Fee_By_Id")]
        public async Task<IActionResult> GetFeeById(string StudentId)
        {
            var data = await _ifeeServices.GetStudentById(StudentId);
            return Ok(data);
        }
        [HttpDelete("Delete_Fee-By-Id")]
        public async Task<IActionResult> DeleteFeeById(string StudentId)
        {
            var data = await _ifeeServices.DeleteFeeById(StudentId);
            return Ok(data);
        }
        [HttpPatch("Update_Fee")]
        public async Task<IActionResult> UpdateFee(string StudentId, FeeRequest FeeRequest)
        {
            var data = await _ifeeServices.UpdateStudent(StudentId, FeeRequest);
            return Ok(data);
        }
    }
}
