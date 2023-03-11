using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.Authority = "https://localhost:44300";
    cfg.Audience = "hangfire";
    cfg.TokenValidationParameters.ValidateAudience = false;
}); ;

TokenValidationParameters GetTokenValidationParameters() => new()
{
    // standard configuration
    ValidIssuer = "https://localhost:44300",
    IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("secret")),
    ValidAudience = "hangfire",
    //ClockSkew = TimeSpan.Zero,

    // security switches
    //RequireExpirationTime = true,
    //ValidateIssuer = true,
    //ValidateIssuerSigningKey = true,
    //ValidateAudience = true,
};
//builder.Services.AddAuthentication(opts =>
//{
//    opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    // Add Jwt token support



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapRazorPages();

app.Run();
