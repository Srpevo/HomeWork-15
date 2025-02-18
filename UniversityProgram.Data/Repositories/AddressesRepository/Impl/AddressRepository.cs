using Microsoft.EntityFrameworkCore;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.AddressesRepository.Abstract;

namespace UniversityProgram.Data.Repositories.AddressesRepository.Impl
{
    public class AddressRepository : IAddressRepository
    {

        private readonly StudentDbContext _dbContext;

        public AddressRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Address address, CancellationToken token = default)
        {
            await _dbContext.Addresses.AddAsync(address, token);
        }

        public void Delete(Address address, CancellationToken token = default)
        {
            _dbContext.Addresses.Remove(address);
        }

        public async Task<IEnumerable<Address>> GetAllAsync(CancellationToken token = default)
        {
            return await _dbContext.Addresses.ToListAsync(token);
        }

        public async Task<Address> GetByIdAsync(int id, CancellationToken token = default)
        {
            return await _dbContext.Addresses.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public void Update(Address address, CancellationToken token = default)
        {
            _dbContext.Addresses.Update(address);
        }
    }
}
