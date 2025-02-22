using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Domain.BaseRepositories
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<Course>> GetAllAsync(CancellationToken token = default);
        public Task AddAsync(Course model, CancellationToken token = default);
        public Task<Course> GetByIdAsync(int id, CancellationToken token = default);
        public Task<Course> GetWithStudentsAsync(int id, CancellationToken token = default);
        public void AddStudent(Course course, CourseStudent courseStudent, CancellationToken token = default);
        public void Delete(Course course, CancellationToken token = default);
        public void Update(Course course, CancellationToken token = default);
    }
}
