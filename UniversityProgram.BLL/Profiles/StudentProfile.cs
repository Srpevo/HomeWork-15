using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProgram.BLL.Models.StudentModels.AddModels;
using UniversityProgram.BLL.Models.StudentModels.UpdateModels;
using UniversityProgram.BLL.Models.StudentModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentModel>();

            CreateMap<StudentAddModel, Student>();

            CreateMap<StudentUpdateModel, Student>();
        }
    }
}
