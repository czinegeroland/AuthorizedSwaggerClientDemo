using Flurl.Http;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace SwaggerClient.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("token")]
        public async Task<IActionResult> Test()
        {
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = $"{"https://localhost:44300"}/connect/token",
                ClientId = "hangfire",
                ClientSecret = "secret",
                Scope = "hangfireapi"

            }).ConfigureAwait(false);
             tokenResponse.HttpResponse.EnsureSuccessStatusCode();

            //using (var fluentClient = new FlurlClient("https://localhost:44383/test/test"))
            //{
            //    var response = await fluentClient
            //        .Request()
            //        .WithOAuthBearerToken(tokenResponse.AccessToken)
            //        .GetAsync();
            //}

            return Ok(tokenResponse.AccessToken);
        }

        [HttpGet("hangfire-api-test")]
        public async Task<IActionResult> HangfireApiTest()
        {
            return Ok("Mukodik");
        }
    }
}
