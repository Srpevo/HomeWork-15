using FluentValidation;
using UniversityProgram.Api.Extensions.AppConfiguringExtensions;
using UniversityProgram.Api.Extensions.ServiceExtensions;
using UniversityProgram.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configure();

var app = builder.Build();

app.Configure();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();
