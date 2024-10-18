using a_zApi.DTO.RequestDto;
using a_zApi.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a_zApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _ibatchService;
        public BatchController(IBatchService ibatchService)
        {
            _ibatchService = ibatchService;
        }
        [HttpPost("Create_Batch")]
        public async Task<IActionResult>CreateBatch(BatchRequest batchRequest)
        {
            var data=await _ibatchService.CreateBatch(batchRequest);
            return Ok(data);
        }
        [HttpGet("Get_All_Batch")]
        public async Task<IActionResult>GetAllBatch()
        {
            var data=await _ibatchService.GetAllBatches();
            return Ok(data);
        }
    }
}
