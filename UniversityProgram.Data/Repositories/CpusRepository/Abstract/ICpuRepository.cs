using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories.CpusRepository.Abstract
{
    public interface ICpuRepository
    {
        public Task<IEnumerable<Cpu>> GetAllAsync(CancellationToken token = default);
        public Task<Cpu> GetByIdAsync(int id, CancellationToken token = default);
        public Task AddAsync(Cpu cpu, CancellationToken token = default);
        public void Update(Cpu cpu, CancellationToken token = default);
        public void Delete(Cpu cpu, CancellationToken token = default);
    }
}
