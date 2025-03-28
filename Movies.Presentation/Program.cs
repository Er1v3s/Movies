
using Microsoft.EntityFrameworkCore;
using Movies.Application;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using Movies.Presentation.Handlers;
using Movies.Presentation.Modules;

namespace Movies.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<MoviesDbContext>(opt =>
            //{
            //    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
            //});

            builder.Services.AddDbContext<MoviesDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
            });

            builder.Services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policyBuilder =>
                {
                    policyBuilder.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddApplication();
            builder.Services.AddExceptionHandler<ExceptionHandler>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using var serviceScope = app.Services.CreateScope();
                using var dbContext = serviceScope.ServiceProvider.GetRequiredService<MoviesDbContext>();
                dbContext?.Database.Migrate();

                Console.WriteLine("Im working");
            }


            app.UseExceptionHandler(_ => { });
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.AddMoviesEndpoints();
            app.Run();
        }
    }
}
