using Microsoft.AspNetCore.Authentication;

namespace SwaggerClient.Infrastructure
{
    public class AuthorizedMiddlewareForOpenID
    {
        private readonly RequestDelegate _next;
        public IConfiguration Configuration { get; }

        public AuthorizedMiddlewareForOpenID(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            Configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect($"{Configuration["OpenIdConnect:Authority"]}/Account/Login");
                await context.ChallengeAsync();
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
