using FluentValidation;
using UniversityProgram.BLL.Models.UniversityModels.AddModels;
using UniversityProgram.BLL.Models.UniversityModels.UpdateModels;
using UniversityProgram.BLL.Models.UniversityModels.ViewModels;

namespace UniversityProgram.BLL.Services.UniversitiesService.Abstract
{
    public interface IUniversityService
    {
        public Task<IEnumerable<UniversityModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(UniversityAddModel model, IValidator<UniversityAddModel> validator, CancellationToken token);
        public Task<UniversityModel> GetByIdAsync(int id, CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task RemoveStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, UniversityUpdateModel model, CancellationToken token);
    }
}
