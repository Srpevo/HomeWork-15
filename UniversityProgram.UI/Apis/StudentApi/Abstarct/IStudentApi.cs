using UniversityProgram.UI.Models;

namespace UniversityProgram.UI.Apis.StudentApi.Abstarct
{
    public interface IStudentApi
    {
        public Task<IEnumerable<StudentModel>> GetAll();
    }
}
