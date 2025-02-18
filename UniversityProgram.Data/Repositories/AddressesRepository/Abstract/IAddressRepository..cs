using UniversityProgram.Data.Entities;

namespace UniversityProgram.Data.Repositories.AddressesRepository.Abstract
{
    public interface IAddressRepository
    {
        public Task AddAsync(Address address, CancellationToken token = default);
        public Task<IEnumerable<Address>> GetAllAsync(CancellationToken token = default);
        public Task<Address> GetByIdAsync(int id, CancellationToken token = default);
        public void Update(Address address, CancellationToken token = default);
        public void Delete(Address address, CancellationToken token = default);
    }
}
