
using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories.UniversitiesRepository.Abstract
{
    public interface IUniversityRepository
    {
        public Task<IEnumerable<University>> GetAllAsync(CancellationToken token = default);
        public Task AddAsync(University university, CancellationToken token = default);
        public Task<University> GetByIdAsync(int id, CancellationToken token = default);
        public void AddStudent(University university, Student student, CancellationToken token = default);
        public void RemoveStudent(University university, Student student, CancellationToken token = default);
        public void Delete(University university, CancellationToken token = default);
        public void Update(University university, CancellationToken token = default);
    }
}
