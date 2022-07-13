using IdentityServerHost;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var identityBuilder = builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;

});

identityBuilder.AddInMemoryIdentityResources(Resources.Identity);
identityBuilder.AddInMemoryClients(Clients.List);
identityBuilder.AddTestUsers(TestUsers.Users);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
