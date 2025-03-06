using Microsoft.AspNetCore.Mvc;
using SmartHealthAPI.Utilities;

namespace SmartHealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<HealthCheckItemController> _logger;

        public TestController(ILogger<HealthCheckItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok("API running");
        }
    }
}
