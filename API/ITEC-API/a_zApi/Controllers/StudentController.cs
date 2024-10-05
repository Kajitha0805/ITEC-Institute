using a_zApi.DTO.RequestDto;
using a_zApi.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _istudentService;
        public StudentController(IStudentService istudentService)
        {
            _istudentService = istudentService;
        }
        [HttpPost("Create_Student")]
        public async Task<IActionResult> CreateProduct(StudentRequest studentRequest)
        {
            var data = await _istudentService.CreateStudent(studentRequest);
            return Ok(data);
        }
        [HttpGet("Get_All_Student")]
        public async Task<IActionResult>GetAllStudent()
        {
            var data=await _istudentService.GetAllStudent();
            return Ok(data);
        }
        [HttpGet("Get_Student_By_Id")]
        public async Task<IActionResult>GetStudentById(Guid StudentId)
        {
            var data = await _istudentService.GetStudentById(StudentId);
            return Ok(data);
        }
        [HttpDelete("Delete_Student-By-Id")]
        public async Task<IActionResult>DeleteStudentById(Guid StudentId)
        {
            var data=await _istudentService.DeleteStudentById(StudentId);
            return Ok(data);
        }
        [HttpPut("Update_Student")]
        public async Task<IActionResult>UpdateStudent(Guid StudentId, StudentRequest studentRequest)
        {
            var data=await _istudentService.UpdateStudent(StudentId, studentRequest);
            return Ok(data);
        }
    }
}
