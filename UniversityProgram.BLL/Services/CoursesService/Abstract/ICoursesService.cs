using FluentValidation;
using UniversityProgram.BLL.Models.CourseModels.AddModels;
using UniversityProgram.BLL.Models.CourseModels.UpdateModels;
using UniversityProgram.BLL.Models.CourseModels.ViewModels;

namespace UniversityProgram.BLL.Services.CoursesService.Abstract
{
    public interface ICoursesService
    {
        public Task<IEnumerable<CourseModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(CourseAddModel model, IValidator<CourseAddModel> validator, CancellationToken token);
        public Task<CourseModel> GetByIdAsync(int id, CancellationToken token);
        public Task<CourseWithStudentsModel> GetWithStudentsAsync(int id, CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, CourseUpdateModel model, CancellationToken token);
    }
}
