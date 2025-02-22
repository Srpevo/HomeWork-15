
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Data.Repositories.CoursesRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbContext _dbContext;

        public CourseRepository(StudentDbContext studentDbContext)
        {
            _dbContext = studentDbContext;
        }

        public async Task<IEnumerable<Course>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Courses.ToListAsync(token);
        }

        public async Task AddAsync(Course course, CancellationToken token = default)
        {
   
            await _dbContext.Courses.AddAsync(course, token);
      
        }

        public async Task<Course> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Courses
                .Include(e => e.CourseStudents)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task<Course> GetWithStudentsAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Courses
                .Include(e => e.CourseStudents)
                .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id, token);

  
        }

        public void AddStudent(Course course ,CourseStudent courseStudent, CancellationToken token = default)
        {      
            course.CourseStudents.Add(courseStudent);
        }

        public void Delete(Course course, CancellationToken token = default)
        {
            _dbContext.Courses.Remove(course);
        }

        public void Update(Course course, CancellationToken token = default)
        {
         
            _dbContext.Courses.Update(course);
 
        }
    }
}
