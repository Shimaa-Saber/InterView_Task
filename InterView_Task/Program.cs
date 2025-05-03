
using InterView_Task.AutoMapper;
using InterView_Task.Interfaces;
using InterView_Task.Models;
using InterView_Task.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InterView_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProduct, ProductRepository>();
            builder.Services.AddScoped<ITransaction, TransactionRepository>();

            // Add services to the container.
            builder.Services.AddDbContext<dbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CS")));


            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                           .AddEntityFrameworkStores<dbContext>()
                           .AddDefaultTokenProviders();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
