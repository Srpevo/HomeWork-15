using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.CpusRepository.Abstract;

namespace UniversityProgram.Data.Repositories.CpusRepository.Impl
{
    public class CpuRepository : ICpuRepository
    {
        private readonly StudentDbContext _dbContext;

        public CpuRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Cpu cpu, CancellationToken token = default)
        {
            await _dbContext.Cpus.AddAsync(cpu, token);
        }

        public void Delete(Cpu cpu, CancellationToken token = default)
        {
            _dbContext.Cpus.Remove(cpu);
        }

        public async Task<IEnumerable<Cpu>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Cpus
                .Include(e => e.Laptop)
                .ToListAsync(token);
        }

        public async Task<Cpu> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Cpus.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void Update(Cpu cpu, CancellationToken token = default)
        {
            _dbContext.Cpus.Update(cpu);
        }
    }
}
