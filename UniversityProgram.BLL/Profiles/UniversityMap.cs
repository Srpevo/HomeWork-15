using UniversityProgram.BLL.Models.UniversityModels.AddModels;
using UniversityProgram.BLL.Models.UniversityModels.ViewModels;
using UniversityProgram.BLL.Profiles;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public static class UniversityMap
    {
        public static UniversityModel Map(this University library)
        {
            return new UniversityModel
            {
                Id = library.Id,
                Name = library.Name,
                Students = library.Students.Select(e => e.Map()).ToList()
            };
        }

        public static University Map(this UniversityAddModel model)
        {
            return new University
            {
                Name = model.Name!,
                Students = model.Students.Select(e => e.Map()).ToList(),
            };
        }
    }
}
