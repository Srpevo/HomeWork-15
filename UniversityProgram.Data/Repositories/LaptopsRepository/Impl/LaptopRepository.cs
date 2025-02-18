using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.LaptopsRepository.Abstract;

namespace UniversityProgram.Data.Repositories.LaptopsRepository.Impl
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly StudentDbContext _dbContext;


        public LaptopRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Laptop>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Laptops
                .Include(e => e.Cpu)
                .ToListAsync(token);
        }

        public async Task AddAsync(Laptop laptop, CancellationToken token = default)
        {
            await _dbContext.Laptops.AddAsync(laptop, token);
        }

        public async Task<Laptop> GetByIdAsync(int id, CancellationToken token = default)
        {
             return await _dbContext.Laptops
                .Include(e => e.Cpu)
                .FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void AddCpu(Cpu cpu, Laptop laptop)
        {
            laptop.Cpu = cpu;
            _dbContext.Update(laptop);
        }

        public void Delete(Laptop laptop, CancellationToken token = default)
        {     
            _dbContext.Laptops.Remove(laptop);
        }

        public void Update(Laptop laptop, CancellationToken token = default)
        {
          _dbContext.Laptops.Update(laptop);
        }
    }
}
