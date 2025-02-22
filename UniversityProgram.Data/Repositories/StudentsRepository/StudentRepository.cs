
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;
namespace UniversityProgram.Data.Repositories.StudentsRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _dbContext;

        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Student student, CancellationToken token = default)
        {
            await _dbContext.Students.AddAsync(student, token);
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Students.ToArrayAsync(token);
        }

        public async Task<Student> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task<Student> GetByIdWithLaptopAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Students
           .Include(e => e.Laptop)
           .ThenInclude(e => e!.Cpu)
           .FirstOrDefaultAsync(e => e.Id == id, token);

        }

        public async Task<Student> GetByIdWithAddressAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Students
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void Update(Student student, CancellationToken token = default)
        {         
            _dbContext.Students.Update(student);
        }

        public void Delete(Student student, CancellationToken token)
        {
            _dbContext.Students.Remove(student);
        }

        public async Task<Student> GetWithCoursesAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Students
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void AddMoney(Student student, decimal money, CancellationToken token = default)
        {
            student.Money += money;
        }

        public async Task PayForCourseAsync(Student student, CourseStudent courseStudent, CancellationToken token = default)
        {
           
            if (student.Money < courseStudent!.Course.Fee) { }

       
            student.Money -= courseStudent.Course.Fee;
            courseStudent.Paid = true;
        }

        public void AddCourse(Student student, Course course, CancellationToken token = default)
        {
            var courseStudent = new CourseStudent()
            {
                Course = course,
                Student = student!
            };

            student.CourseStudents.Add(courseStudent);

        }
    }
}
