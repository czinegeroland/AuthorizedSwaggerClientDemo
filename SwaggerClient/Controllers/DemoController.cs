using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerClient.Controllers
{
    [Authorize(Roles = "DemoRole")]
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
