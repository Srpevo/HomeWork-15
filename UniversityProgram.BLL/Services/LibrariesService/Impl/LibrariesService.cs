
using AutoMapper;
using FluentValidation;
using UniversityProgram.BLL.Models.LibraryModels.AddModels;
using UniversityProgram.BLL.Models.LibraryModels.UpdateModels;
using UniversityProgram.BLL.Models.LibraryModels.ViewModels;
using UniversityProgram.BLL.Services.LibrariesService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;


namespace UniversityProgram.BLL.Services.LibrariesService.Impl
{
    public class LibrariesService : ILibraryService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public LibrariesService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<LibraryModel>> GetAllAsync(CancellationToken token)
        {
            var Libraries = await _uow.LibraryRepository.GetAllAsync(token);
            return Libraries.Select(e => _mapper.Map<LibraryModel>(e));
        }

        public async Task AddAsync(LibraryAddModel model, IValidator<LibraryAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _uow.LibraryRepository.AddAsync(_mapper.Map<Library>(model), token);
            await _uow.Save(token);
        }

        public async Task<LibraryModel> GetByIdAsync(int id, CancellationToken token)
        {
            var library = await _uow.LibraryRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(library);
            return _mapper.Map<LibraryModel>(library);
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var library = await _uow.LibraryRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(library);

            library.Students.Add(student);
            await _uow.Save(token);
        }

        public async Task RemoveStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var library = await _uow.LibraryRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(library);

            library!.Students.Remove(student!);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var library = await _uow.LibraryRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(library);

            _uow.LibraryRepository.Delete(library, token);
            await _uow.Save(token);
        }

        public async Task UpdateAsync(int id, LibraryUpdateModel model, CancellationToken token)
        {
            var library = await _uow.LibraryRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(library);

            library!.Name = model.Name ?? library.Name;

            _uow.LibraryRepository.Update(library);

            await _uow.Save(token);
        }
    }
}
