using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SwaggerClient.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Demo API",
        Version = "v1",
        License = new OpenApiLicense()
    });

});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.Authority = "https://localhost:44300";
    options.ClientId = "demo";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.GetClaimsFromUserInfoEndpoint = true;
    options.Scope.Add("DemoRole");
    options.Scope.Add("offline_access");
    options.ClaimActions.MapJsonKey("swagger_role", "swagger_role");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        RoleClaimType = "swagger_role"
    };
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseMiddleware<AuthorizedMiddlewareForOpenID>();
app.UseMiddleware<AuthorizedAccessDeniedMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("swagger/v1/swagger.json", "Demo API");
    c.OAuthScopeSeparator(" ");
    c.OAuthUsePkce();
});

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapRazorPages();

app.Run();
