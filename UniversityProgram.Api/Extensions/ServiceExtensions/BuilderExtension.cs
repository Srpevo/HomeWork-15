using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Profiles;
using UniversityProgram.BLL.Services.AddressService.Abstract;
using UniversityProgram.BLL.Services.AddressService.Impl;
using UniversityProgram.BLL.Services.CourseBankService.Abstract;
using UniversityProgram.BLL.Services.CourseBankService.Impl;
using UniversityProgram.BLL.Services.CoursesService.Abstract;
using UniversityProgram.BLL.Services.CoursesService.Impl;
using UniversityProgram.BLL.Services.CpuService.Abstract;
using UniversityProgram.BLL.Services.CpuService.Impl;
using UniversityProgram.BLL.Services.LaptopsService.Abstract;
using UniversityProgram.BLL.Services.LaptopsService.Impl;
using UniversityProgram.BLL.Services.LibrariesService.Abstract;
using UniversityProgram.BLL.Services.LibrariesService.Impl;
using UniversityProgram.BLL.Services.StudentsService.Abstract;
using UniversityProgram.BLL.Services.StudentsService.Impl;
using UniversityProgram.BLL.Services.UniversitiesService.Abstract;
using UniversityProgram.BLL.Services.UniversitiesService.Impl;
using UniversityProgram.BLL.Validators.LaptopValidators;
using UniversityProgram.Data;
using UniversityProgram.Data.Repositories.UnitOfWork;
using UniversityProgram.Domain.BaseRepositories;


namespace UniversityProgram.Api.Extensions.ServiceExtensions
{
    public static class BuilderExtension
    {
        public static void Configure(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICourseBankService, CourseBankServiceApi>();
            builder.Services.AddScoped<IStudentsService, StudentsService>();
            builder.Services.AddScoped<ILaptopsService, LaptopsService>();
            builder.Services.AddScoped<ILibraryService, LibrariesService>();
            builder.Services.AddScoped<ICoursesService, CoursesService>();
            builder.Services.AddScoped<IUniversityService, UniversityService>();
            builder.Services.AddScoped<ICpuService, CpuService>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(LaptopProfile));
            builder.Services.AddValidatorsFromAssemblyContaining<LaptopAddModelValidator>(ServiceLifetime.Transient);
            builder.Services.AddSignalR();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["Auth0:Authority"];
                options.Audience = builder.Configuration["Auth0:Audience"];
            });

            builder.Services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
        }
    }
}
