using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Extensions.ServiceExtensions;
using UniversityProgram.Api.Middlewares;
using UniversityProgram.BLL.Profiles;
using UniversityProgram.BLL.Validators.LaptopValidators;
using UniversityProgram.Data;
using UniversityProgram.Data.Repositories.UnitOfWork;
using UniversityProgram.Domain.BaseRepositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProjectServicesScoped();

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));




var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();



app.MapControllers();



app.Run();
