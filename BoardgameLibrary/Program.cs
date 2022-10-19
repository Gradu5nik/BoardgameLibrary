using BoardgameLibrary.BoardgameManagement;
using EFCoreBoardgameData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//DbAccess

builder.Services.AddDbContext<EFCoreBoardgameDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        assembly => assembly.MigrationsAssembly(typeof(EFCoreBoardgameDbContext).Assembly.FullName));
});
//Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<EFCoreBoardgameDbContext>();
builder.Services.AddScoped<AuthenticationStateProvider,ServerAuthenticationStateProvider>();

//CustomServices
builder.Services.AddScoped<IBoardgameRepository,BoardgameRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//Identity
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
