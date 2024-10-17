using a_zApi.DTO.RequestDto;
using a_zApi.IServices;
using a_zApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowUpController : ControllerBase
    {
        private readonly IFollowUpService _ifollowUpService;

        public FollowUpController(IFollowUpService ifollowUpService)
        {
            _ifollowUpService = ifollowUpService;
        }
        [HttpPost("Create_FollowUp")]
        public async Task<IActionResult>CreateFollowUp(FollowUpRequestDto followUpRequestDto)
        {
            var data = await _ifollowUpService.CreateFollowUp(followUpRequestDto);
            return Ok(data);
        }
        [HttpGet("Get_FollowStudentBy_Name")]
        public async Task<IActionResult>GetFollowUpById(string Name)
        {
            var data=await _ifollowUpService.GetFollowUpById(Name);
            return Ok(data);
        }
        [HttpDelete("Delete_FollowUp")]
        public async Task<IActionResult>DeleteFollowUpById(string Name)
        {
            var data = await _ifollowUpService.DeleteFollowUpById(Name);
            return Ok(data);
        }
        [HttpGet("Get_All_FollowUps")]
        public async Task<IActionResult>GetAllFollowUps()
        {
            var data=await _ifollowUpService.GetAllFollowUps();
            return Ok(data);
        }
    }
}
