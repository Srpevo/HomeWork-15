using AutoMapper;
using UniversityProgram.BLL.Models.LibraryModels.AddModels;
using UniversityProgram.BLL.Models.LibraryModels.UpdateModels;
using UniversityProgram.BLL.Models.LibraryModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Library, LibraryModel>();

            CreateMap<LibraryAddModel, Library>();

            CreateMap<LibraryUpdateModel, Library>();
        }
    }
}
