using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Map;
using UniversityProgram.BLL.Models.CourseModels.AddModels;
using UniversityProgram.BLL.Models.CourseModels.UpdateModels;
using UniversityProgram.BLL.Models.CourseModels.ViewModels;
using UniversityProgram.BLL.Services.CoursesService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Data;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.UnitOfWork.Abstract;

namespace UniversityProgram.BLL.Services.CoursesService.Impl
{
    public class CoursesService : ICoursesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CoursesService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<CourseModel>> GetAllAsync(CancellationToken token)
        {
            var courses = await _uow.CourseRepository.GetAllAsync(token);
            return courses.Select(e => _mapper.Map<CourseModel>(e));
        }

        public async Task AddAsync(CourseAddModel model, IValidator<CourseAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            var course = _mapper.Map<Course>(model);
            await _uow.CourseRepository.AddAsync(course, token);
            await _uow.Save(token);
        }

        public async Task<CourseModel> GetByIdAsync(int id, CancellationToken token)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(course);
            return _mapper.Map<CourseModel>(course);
        }

        public async Task<CourseWithStudentsModel> GetWithStudentsAsync(int id, CancellationToken token)
        {
            var course = await _uow.CourseRepository.GetWithStudentsAsync(id, token);

            ObjectValidator.ThrowIfNull(course);

            return course!.MapCourseWithStudentsModel();
        }

        public async Task AddStudentAsync(int id, int studentId, CancellationToken token)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(course);

            var student = await _uow.StudentRepository.GetByIdAsync(studentId, token);
            ObjectValidator.ThrowIfNull(student);

            var courseStudent = new CourseStudent
            {
                Course = course!,
                Student = student!,
            };

            _uow.CourseRepository.AddStudent(course, courseStudent, token);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(course);

            _uow.CourseRepository.Delete(course, token);
            await _uow.Save(token);
        }

        public async Task UpdateAsync(int id, CourseUpdateModel model, CancellationToken token)
        {
            var course = await _uow.CourseRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(course);

            course!.Name = model.Name ?? course.Name;
            course.Fee = model.Fee;

            _uow.CourseRepository.Update(course, token);
            await _uow.Save(token);
        }
    }
}
