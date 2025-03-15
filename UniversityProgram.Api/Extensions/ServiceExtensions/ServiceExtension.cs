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

namespace UniversityProgram.Api.Extensions.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static void AddProjectServicesScoped(this IServiceCollection services)
        {
            services.AddScoped<ICourseBankService, CourseBankServiceApi>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ILaptopsService, LaptopsService>();
            services.AddScoped<ILibraryService, LibrariesService>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<ICpuService, CpuService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {

                    builder.WithOrigins("...")
                    .AllowAnyMethod()
                    .AllowAnyHeader();

                });
            });
        }
    }
}
