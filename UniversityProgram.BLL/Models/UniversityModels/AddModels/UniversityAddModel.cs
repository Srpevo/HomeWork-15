using UniversityProgram.BLL.Models.StudentModels.AddModels;

namespace UniversityProgram.BLL.Models.UniversityModels.AddModels
{
    public class UniversityAddModel
    {
        public string? Name { get; set; }
        public IEnumerable<StudentAddModel> Students { get; set; } = new List<StudentAddModel>();
    }
}
