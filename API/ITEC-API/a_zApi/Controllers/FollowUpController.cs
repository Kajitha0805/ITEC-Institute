using a_zApi.IServices;
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
    }
}
