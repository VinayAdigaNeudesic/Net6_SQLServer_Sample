using Microsoft.EntityFrameworkCore;
using Sample_API.Data;
using Sample_API.Controllers;

namespace Sample_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
                dataContext.Database.Migrate();
            }

            app.Run();
        }
    }
}