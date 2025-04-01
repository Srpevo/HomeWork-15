using UniversityProgram.Api.Hubs;

namespace UniversityProgram.Api.Extensions.AppConfiguringExtensions
{
    public static class AppConfigureExtension
    {
        public static void Configure(this WebApplication app)
        {
            app.UseCors(policy =>
                 policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.MapHub<StudentsHub>("/studentshub");
        }
    }
}
