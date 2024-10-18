using a_zApi.DTO.RequestDto;
using a_zApi.Enitity;
using a_zApi.IServices;
using a_zApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrollmentController : ControllerBase
    {

        private readonly IEntrollmentService _entrollmentService;
        public EntrollmentController(IEntrollmentService entrollmentService)
        {
            _entrollmentService = entrollmentService;
        }


        [HttpPost("Create_Enrollment")]
        public async Task<IActionResult> CreateEnrollment(EntrollmentRequest enrollmentRequest)
        {
            // Convert EntrollmentRequest to Entrollment
            var enrollment = new Entrollment
            {
               
                NicNo = enrollmentRequest.NicNo,
                CourseId = enrollmentRequest.CourseId
            };

            // Pass the Entrollment object to the service
            var data = await _entrollmentService.CreateEntrollment(enrollment);
            return Ok(data);
        }



        [HttpGet("Get_All_Entrollment")]
        public async Task<IActionResult> GetAllEntrollment()
        {
            var data = await _entrollmentService.GetAllEntrollment();
            return Ok(data);
        }
        [HttpGet("Get_Entrollment_By_Id")]
        public async Task<IActionResult> GetEntrollmentById(string NicNo)
        {
            var data = await _entrollmentService.GetEntrollment(NicNo);
            return Ok(data);
        }
        [HttpDelete("Delete_Entrollment-By-Id")]
        public async Task<IActionResult> DeleteEntrollmentById(string NicNo)
        {
            var data = await _entrollmentService.DeleteEnrollmentById(NicNo);
            return Ok(data);
        }
        [HttpPatch("Update_Entrollment")]
        public async Task<IActionResult> UpdateEntrollment(string NicNo, EntrollmentRequest studentRequest)
        {
            var data = await _entrollmentService.UpdateEntrollment(NicNo, studentRequest);
            return Ok(data);
        }
    }
}
