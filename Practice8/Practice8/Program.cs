//gpts davawerine shemtxvevit mvc shevqmeni da gadavakete gviani iyo tavidan dasawyebad yvelaferi mqonda
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Practice_8.Data;
using Practice_8.Interfaces;
using Practice_8.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Practice8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Add DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Add MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add Repositories
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IMusicRepository, MusicRepository>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen((SwaggerGenOptions c) =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practice8 API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice8 API V1");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
