using FluentValidation;
using UniversityProgram.BLL.Models.LibraryModels.AddModels;
using UniversityProgram.BLL.Models.LibraryModels.UpdateModels;
using UniversityProgram.BLL.Models.LibraryModels.ViewModels;

namespace UniversityProgram.BLL.Services.LibrariesService.Abstract
{
    public interface ILibraryService
    {
        public Task<IEnumerable<LibraryModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(LibraryAddModel model, IValidator<LibraryAddModel> validator, CancellationToken token);
        public Task<LibraryModel> GetByIdAsync(int id, CancellationToken token);
        public Task AddStudentAsync(int id, int studentId, CancellationToken token);
        public Task RemoveStudentAsync(int id, int studentId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, LibraryUpdateModel model, CancellationToken token);
    }
}
