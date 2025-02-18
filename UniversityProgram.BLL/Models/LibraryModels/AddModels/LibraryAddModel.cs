using UniversityProgram.BLL.Models.StudentModels.AddModels;

namespace UniversityProgram.BLL.Models.LibraryModels.AddModels
{
    public class LibraryAddModel
    {
        public string? Name { get; set; }
        public ICollection<StudentAddModel> Students { get; set; } = new List<StudentAddModel>();
    }
}
