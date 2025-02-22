using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Domain.BaseRepositories
{
    public interface ILibraryRepository
    {
        public Task<IEnumerable<Library>> GetAllAsync(CancellationToken token = default);
        public Task AddAsync(Library library, CancellationToken token = default);
        public Task<Library> GetByIdAsync(int id, CancellationToken token = default);
        public void AddStudent(Library library,Student student, CancellationToken token = default);
        public void RemoveStudent(Library library, Student student, CancellationToken token = default);
        public void Delete(Library library, CancellationToken token = default);
        public void Update(Library library, CancellationToken token = default);
    }
}
