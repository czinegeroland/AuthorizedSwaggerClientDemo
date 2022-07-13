using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerClient.Controllers
{
    [Authorize(Roles = "DemoRole")]
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("number")]
        public async Task<IActionResult> Get()
        {
            return Ok(1);
        }
    }
}
