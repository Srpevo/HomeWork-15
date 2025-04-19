using UniversityProgram.UI.Models.StudentModels;

namespace UniversityProgram.UI.Apis.StudentApi.Abstract
{
    public interface IStudentApi
    {
        public Task<IEnumerable<StudentModel>> GetAll();
        public Task<StudentModel> GetById(int id);
        public Task Add(StudentAddModel model);
        public Task Delete(int id);
        public Task Update(int id, StudentUpdateModel model);
    }
}
