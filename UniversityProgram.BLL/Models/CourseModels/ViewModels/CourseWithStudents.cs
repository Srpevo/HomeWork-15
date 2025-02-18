using UniversityProgram.BLL.Models.StudentModels.ViewModels;

namespace UniversityProgram.BLL.Models.CourseModels.ViewModels
{
    public class CourseWithStudentsModel : CourseModel
    {
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
