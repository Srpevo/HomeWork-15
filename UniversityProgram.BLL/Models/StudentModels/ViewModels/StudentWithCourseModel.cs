using UniversityProgram.BLL.Models.CourseModels.ViewModels;

namespace UniversityProgram.BLL.Models.StudentModels.ViewModels
{
    public class StudentWithCourseModel : StudentModel
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
