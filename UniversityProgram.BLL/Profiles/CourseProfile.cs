using AutoMapper;
using UniversityProgram.BLL.Models.CourseModels.AddModels;
using UniversityProgram.BLL.Models.CourseModels.UpdateModels;
using UniversityProgram.BLL.Models.CourseModels.ViewModels;
using UniversityProgram.Domain.Entities;


namespace UniversityProgram.BLL.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseModel>();

            CreateMap<CourseAddModel, Course>();

            CreateMap<CourseUpdateModel, Course>();
        }
    }
}
