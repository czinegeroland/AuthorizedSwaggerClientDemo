using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SwaggerClient.Infrastructure
{
    public class AuthorizedAccessDeniedMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizedAccessDeniedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/Account/AccessDenied")
                && context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
