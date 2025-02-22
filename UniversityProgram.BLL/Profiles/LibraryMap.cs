using UniversityProgram.BLL.Models.LibraryModels.AddModels;
using UniversityProgram.BLL.Models.LibraryModels.ViewModels;
using UniversityProgram.BLL.Profiles;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public static class LibraryMap
    {
        public static LibraryModel Map(this Library library)
        {
            return new LibraryModel
            {
                Id = library.Id,
                Name = library.Name,
                Students = library.Students.Select(e => e.Map()).ToList()
            };
        }

        public static Library Map(this LibraryAddModel model)
        {
            return new Library
            {
                Name = model.Name!,
                Students = model.Students.Select(e => e.Map()).ToList(),
            };
        }
    }
}
