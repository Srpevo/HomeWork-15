using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProgram.BLL.Models.CpuModels.AddModels;
using UniversityProgram.BLL.Models.CpuModels.UpdateModels;
using UniversityProgram.BLL.Models.CpuModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public class CpuProfile : Profile
    {
        public CpuProfile()
        {
            CreateMap<Cpu, CpuModel>();

            CreateMap<CpuAddModel, Cpu>();

            CreateMap<CpuUpdateModel, Cpu>();
        }
    }
}
