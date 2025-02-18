using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProgram.BLL.Models.UniversityModels.AddModels;
using UniversityProgram.BLL.Models.UniversityModels.UpdateModels;
using UniversityProgram.BLL.Models.UniversityModels.ViewModels;
using UniversityProgram.Data.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public class UniversityProfile : Profile
    {
        public UniversityProfile()
        {
            CreateMap<University, UniversityModel>();

            CreateMap<UniversityUpdateModel, University>();

            CreateMap<UniversityAddModel, University>();
        }
    }
}
