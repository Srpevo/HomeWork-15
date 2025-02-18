using UniversityProgram.BLL.Models.StudentModels.ViewModels;

namespace UniversityProgram.BLL.Models.LibraryModels.ViewModels
{
    public class LibraryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
