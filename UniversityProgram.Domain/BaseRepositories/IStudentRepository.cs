using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Domain.BaseRepositories
{
    public interface IStudentRepository
    {
        public Task AddAsync(Student student, CancellationToken token = default);
        public Task<IEnumerable<Student>> GetAllAsync(CancellationToken token = default);
        public Task<Student> GetByIdAsync(int id, CancellationToken token = default);
        public Task<Student> GetByIdWithLaptopAsync(int id, CancellationToken token = default);
        public Task<Student> GetByIdWithAddressAsync(int id, CancellationToken token = default);
        public void Update(Student student, CancellationToken token = default);
        public void Delete(Student student, CancellationToken token = default);
        public Task<Student> GetWithCoursesAsync(int id, CancellationToken token = default);
        public void AddMoney(Student student, decimal money, CancellationToken token = default);
        public void AddCourse(Student student, Course course, CancellationToken token = default);
    }
}
