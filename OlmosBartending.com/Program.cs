using OlmosBartending.com.Services;
using OlmosBartending.com.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GoogleReCaptcha.V3.Interface;
using GoogleReCaptcha.V3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICRUD, DBcrud>();
//builder.Services.AddDbContext<UserContext>(options => options.UseSqlite("Data Source=UserList.db"));
//builder.Services.AddDbContext<AppointmentContext>(options => options.UseSqlite("Data Source=AppointmentList.db"));
builder.Services.AddDbContext<AppointmentContext>(options => options.UseSqlServer("Server=SIERX\\SQLEXPRESS;Database=OlmosAppointmentList;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True"));
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=SIERX\\SQLEXPRESS;Database=OlmosUsers;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True"));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Lockout.MaxFailedAccessAttempts = 4;
}).AddEntityFrameworkStores<UserContext>();
//builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=SIERX\\SQLEXPRESS;Database=OlmosAdmin;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var userDbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    userDbContext.Database.EnsureCreated();
    var appointmentDbContext = scope.ServiceProvider.GetRequiredService<AppointmentContext>();
    appointmentDbContext.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
