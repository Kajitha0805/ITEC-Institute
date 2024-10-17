using a_zApi.DTO.RequestDto;
using a_zApi.Enitity;
using a_zApi.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpModuleController : ControllerBase
    {
        private readonly IUpModuleService _iupModuleService;
        public UpModuleController(IUpModuleService iupModuleService)
        {
            _iupModuleService = iupModuleService;
        }
        [HttpPost("Upload_Module")]
        public async Task<IActionResult>CreateUploadModule(UploadModuleRequest uploadModuleRequest)
        {
            var data=await _iupModuleService.CreateUploadModule(uploadModuleRequest);
            return Ok(data);

        }
        [HttpGet("Get_All_UpModule")]
        public async Task<IActionResult>GetAllUpModule()
        {
            var data=await _iupModuleService.GetAllUpModules();
            return Ok(data);
        }
    }
}
