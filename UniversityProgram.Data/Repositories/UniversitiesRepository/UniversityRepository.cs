using Microsoft.EntityFrameworkCore;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;


namespace UniversityProgram.Data.Repositories.UniversitiesRepository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly StudentDbContext _dbContext;

        public UniversityRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<University>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Universities
                .Include(e => e.Students)
                .ToListAsync(token);
        }

        public async Task AddAsync(University university, CancellationToken token = default)
        {
            await _dbContext.Universities.AddAsync(university, token);  
        }

        public async Task<University> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Universities
                .Include(e => e.Students)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void AddStudent(University university, Student student, CancellationToken token = default)
        { 
            university.Students.Add(student);
        }

        public void RemoveStudent(University university, Student student, CancellationToken token = default)
        {
            university.Students.ToList().Remove(student);
        }

        public void Delete(University university, CancellationToken token = default)
        {
            _dbContext.Universities.Remove(university);
        }

        public void Update(University university, CancellationToken token = default)
        {
            _dbContext.Universities.Update(university);
        }
    }
}
