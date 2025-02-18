
using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.LibrariesRepository.Abstract;

namespace UniversityProgram.Data.Repositories.LibrariesRepository.Impl
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly StudentDbContext _dbContext;

        public LibraryRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Library>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Libraries
                .Include(e => e.Students)
                .ToListAsync(token);
        }

        public async Task AddAsync(Library library, CancellationToken token = default)
        {
            await _dbContext.Libraries.AddAsync(library, token);
        }

        public async Task<Library> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Libraries
                .Include(e => e.Students)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void AddStudent(Library library, Student student, CancellationToken token = default)
        {
            library.Students.Add(student);
        }

        public void RemoveStudent(Library library, Student student, CancellationToken token = default)
        {
            library.Students.Remove(student);
        }

        public void Delete(Library library, CancellationToken token = default)
        {
            _dbContext.Libraries.Remove(library);
        }

        public void Update(Library library, CancellationToken token = default)
        {
            _dbContext.Libraries.Update(library);
        }
    }
}
