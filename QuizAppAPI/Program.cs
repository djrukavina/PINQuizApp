using Microsoft.EntityFrameworkCore;
using QuizAppAPI.Context;
using QuizAppAPI.Controllers;
using QuizAppAPI.Models;
using QuizAppAPI.Services;

namespace QuizAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnString not found.")));
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<PlayedQuizService>();
            //builder.Services.AddScoped<FetchQuizModel>();

            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient("opentdb", url => { url.BaseAddress = new Uri("https://opentdb.com/api.php"); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
