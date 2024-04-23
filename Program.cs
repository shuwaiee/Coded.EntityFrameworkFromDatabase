using EntityFrameworkFromDatabase.Models;
using EntityFrameworkFromDatabase.Services;
using EntityFrameworkFromDatabase.Services.Implemetation;
using EntityFrameworkFromDatabase.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFromDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IEmailService, ExchangeeMailService>();
            builder.Services.AddScoped<IOtpGenerator, FakeOtpGenerator>();

            builder.Services.AddDbContext<StudentDbContext>
                (option => 
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            // Transient (New Each Time)
            // Scoped New (Same for one request)
            // Singleton (Same for all)
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
