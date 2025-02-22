using AutoMapper;
using UniversityProgram.BLL.Models.LaptopModels.AddModels;
using UniversityProgram.BLL.Models.LaptopModels.UpdateModels;
using UniversityProgram.BLL.Models.LaptopModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public class LaptopProfile : Profile
    {
        public LaptopProfile()
        {
            CreateMap<Laptop, LaptopModel>();

            CreateMap<LaptopAddModel, Laptop>();

            CreateMap<LaptopUpdateModel, Laptop>();
        }
    }
}
