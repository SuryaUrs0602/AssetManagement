using AssetManagement.Models;
using AssetManagement.Repositories;
using AssetManagement.Repository;
using AssetManagement.Repository.Contracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AssetDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MySqlServer")));

//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();
//Di for Hardware
//Di for Software
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.UseExceptionHandler(options =>
//{
//    options.Run(
//        async context =>
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//            var message = context.Features.Get<IExceptionHandlerFeature>();
//            if (message != null)
//            {
//                await context.Response.WriteAsync(message.Error.Message);
//            }
//        });
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
