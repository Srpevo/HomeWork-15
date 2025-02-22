using UniversityProgram.Domain.Entities;

namespace UniversityProgram.Domain.BaseRepositories
{
    public interface ILaptopRepository
    {
        public Task<IEnumerable<Laptop>> GetAllAsync(CancellationToken token = default);
        public Task AddAsync(Laptop laptop, CancellationToken token = default);
        public Task<Laptop> GetByIdAsync(int id, CancellationToken token = default);
        public void AddCpu(Cpu cpu, Laptop laptop);
        public void Delete(Laptop cpu, CancellationToken token = default);
        public void Update(Laptop cpu, CancellationToken token = default);
    }
}
