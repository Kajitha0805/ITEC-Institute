using a_zApi.DTO.RequestDto;
using a_zApi.DTO.ResponseDto;
using a_zApi.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegisterController : ControllerBase
    {
        private IStudentRegisterService _studentRegisterService;

        public StudentRegisterController(IStudentRegisterService studentRegisterService)
        {
            _studentRegisterService = studentRegisterService;
        }

        [HttpPost]
        public ActionResult<StudentRegisterResponse> CreateStudentRegister([FromBody] StudentRegisterRequest requestDto)
        {
            var response = _studentRegisterService.AddStudentRegister(requestDto);
            return CreatedAtAction(nameof(CreateStudentRegister), response);
        }

        [HttpGet("{nicNo}")]
        public ActionResult<StudentRegisterResponse> GetStudentRegister(string nicNo)
        {
            var response = _studentRegisterService.GetStudentRegister(nicNo);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        [HttpGet]
        public ActionResult<IEnumerable<StudentRegisterResponse>> GetAllStudentRegister()
        {
            var studentRegister = _studentRegisterService.GetAllStudentRegister();
            return Ok(studentRegister);
        }


        [HttpPut("{nicNo}")]
        public ActionResult<StudentRegisterResponse> UpdateStudentRegister(string nicNo, [FromBody] StudentRegisterRequest requestDto)
        {
            var response = _studentRegisterService.UpdateStudentRegisterResponse(nicNo, requestDto);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        [HttpDelete("{nicNo}")]
        public IActionResult DeleteStudentRegister(string nicNo)
        {
            var result = _studentRegisterService.DeleteStudentRegister(nicNo);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}

