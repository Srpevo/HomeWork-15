using AutoMapper;
using FluentValidation;
using UniversityProgram.BLL.Models.UniversityModels.AddModels;
using UniversityProgram.BLL.Models.UniversityModels.UpdateModels;
using UniversityProgram.BLL.Models.UniversityModels.ViewModels;
using UniversityProgram.BLL.Services.UniversitiesService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Services.UniversitiesService.Impl
{
    public class UniversityService : IUniversityService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UniversityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync(CancellationToken token)
        {
            var universities = await _uow.UniversityRepository.GetAllAsync(token);
            return universities.Select(e => _mapper.Map<UniversityModel>(e));
        }

        public async Task AddAsync(UniversityAddModel model, IValidator<UniversityAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _uow.UniversityRepository.AddAsync(_mapper.Map<University>(model), token);
            await _uow.Save(token);
        }

        public async Task<UniversityModel> GetByIdAsync(int id, CancellationToken token)
        {
            var university = await _uow.UniversityRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(university);
            return _mapper.Map<UniversityModel>(university);
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var university = await _uow.UniversityRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(university);

            university!.Students.Add(student!);
            await _uow.Save(token);
        }

        public async Task RemoveStudentAsync(int id, int studentId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var university = await _uow.UniversityRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(university);

            _uow.UniversityRepository.RemoveStudent(university, student, token);

            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var university = await _uow.UniversityRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(university);

            _uow.UniversityRepository.Delete(university);
            await _uow.Save(token);
        }

        public async Task UpdateAsync(int id, UniversityUpdateModel model, CancellationToken token)
        {
            var university = await _uow.UniversityRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(university);

            university!.Name = model.Name ?? university.Name;

            await _uow.Save(token);
        }
    }
}
