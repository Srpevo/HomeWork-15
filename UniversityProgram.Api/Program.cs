using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Api.Extensions.AppConfiguringExtensions;
using UniversityProgram.Api.Extensions.ServiceExtensions;
using UniversityProgram.Api.Middlewares;
using UniversityProgram.Data;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProjectServicesScoped();

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));




var app = builder.Build();

app.Configure();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();


app.MapControllers();



app.Run();
