using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UniversityProgram.BLL.Models.StudentModels.AddModels;
using UniversityProgram.BLL.Models.StudentModels.UpdateModels;
using UniversityProgram.BLL.Models.StudentModels.ViewModels;
using UniversityProgram.BLL.Services.CourseBankService.Impl;

namespace UniversityProgram.BLL.Services.StudentsService.Abstract
{
    public interface IStudentsService
    {
        public Task AddAsync(StudentAddModel model, IValidator<StudentAddModel> validator, CancellationToken token);
        public Task<IEnumerable<StudentModel>> GetAllAsync(CancellationToken token);
        public Task<StudentModel> GetByIdAsync(int id, CancellationToken token);
        public Task<StudentWithLaptopModel> GetByIdWithLaptopAsync(int id, CancellationToken token);
        public Task<StudentWithAddressModel> GetByIdWithAddressAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, StudentUpdateModel model, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task<StudentWithCourseModel> GetWithCoursesAsync(int id, CancellationToken token);
        public Task AddMoneyAsync(int id, decimal money, CancellationToken token);
        public Task PayForCourseAsync([FromRoute] int id, int courseId, CourseBankServiceApi bankApi, CancellationToken token);
        public Task AddCourseAsync(int id, int courseId, CancellationToken token);
    }
}
