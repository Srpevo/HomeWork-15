using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProgram.BLL.Models.CourseModels.AddModels;
using UniversityProgram.BLL.Models.CourseModels.UpdateModels;
using UniversityProgram.BLL.Models.CourseModels.ViewModels;
using UniversityProgram.Data.Entities;

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
