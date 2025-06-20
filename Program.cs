using Microsoft.EntityFrameworkCore;
using ThesisMate.Repositories;
using ThesisMate.Services;
using ThesisMate.Models;


var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ThesisMateContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IStudentRepository, StudentService>();
    builder.Services.AddScoped<ISupervisorRepository, SupervisorService>();
    builder.Services.AddScoped<IAuthenticationRepository, AuthenticationService>();
    builder.Services.AddScoped<IUserRepository, UserService>();
    builder.Services.AddScoped<IFileRepository, FileService>();
    
    builder.Services.AddSession(options => {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{   

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
    app.UseSession();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
