using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniversityProgram.BLL.Map;
using UniversityProgram.BLL.Models.StudentModels.AddModels;
using UniversityProgram.BLL.Models.StudentModels.UpdateModels;
using UniversityProgram.BLL.Models.StudentModels.ViewModels;
using UniversityProgram.BLL.Services.CourseBankService.Impl;
using UniversityProgram.BLL.Services.StudentsService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Data;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.UnitOfWork.Abstract;

namespace UniversityProgram.BLL.Services.StudentsService.Impl
{
    public class StudentsService : IStudentsService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public StudentsService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task AddAsync(StudentAddModel model, IValidator<StudentAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            var student = model.Map();

            await _uow.StudentRepository.AddAsync(student, token);
            await _uow.Save(token);
        }

        public async Task<IEnumerable<StudentModel>> GetAllAsync(CancellationToken token)
        {
            var students = await _uow.StudentRepository.GetAllAsync(token);
            return students.Select(e => _mapper.Map<StudentModel>(e));
        }

        public async Task<StudentModel> GetByIdAsync(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(student);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<StudentWithLaptopModel> GetByIdWithLaptopAsync(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithLaptopAsync(id, token);

            ObjectValidator.ThrowIfNull(student);

            return student!.MapToStudentWithLaptop();
        }

        public async Task<StudentWithAddressModel> GetByIdWithAddressAsync(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdWithAddressAsync(id, token);

            ObjectValidator.ThrowIfNull(student);
            return student!.MapToStudentWithAddress();
        }

        public async Task UpdateAsync(int id, StudentUpdateModel model, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(student);
            student!.Name = model.Name ?? student.Name;
            student!.Email = model.Email is not null ? model.Email : student.Email;
            _uow.StudentRepository.Update(student);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(student);
            _uow.StudentRepository.Delete(student);
            await _uow.Save(token);
        }

        public async Task<StudentWithCourseModel> GetWithCoursesAsync(int id, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetWithCoursesAsync(id, token);

            ObjectValidator.ThrowIfNull(student);

            return student!.MapStudentWithCourseModel();
        }

        public async Task AddMoneyAsync(int id, decimal money, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(student);
            student!.Money += money;
            await _uow.Save(token);
        }

        public async Task PayForCourseAsync(int id, int courseId, CourseBankServiceApi bankApi, CancellationToken token)
        {
            //TODO: Implement this method

        }

        public async Task AddCourseAsync(int id, int courseId, CancellationToken token)
        {
            var student = await _uow.StudentRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(student);

            var course = await _uow.CourseRepository.GetByIdAsync(courseId, token);
            ObjectValidator.ThrowIfNull(course);

            var courseStudent = new CourseStudent()
            {
                Course = course!,
                Student = student!
            };

            student.CourseStudents.Add(courseStudent);

            await _uow.Save(token);

        }
    }
}
