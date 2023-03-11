using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtClient.Controller
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Teszt");
        }
    }
}
