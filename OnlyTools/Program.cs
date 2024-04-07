using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Services;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.IdentityModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OnlyToolsDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<OnlyToolsDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/User/Logout";
});
builder.Services.AddScoped<IToolServices, ToolServices>();
builder.Services.AddScoped<ITipServices, TipServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
