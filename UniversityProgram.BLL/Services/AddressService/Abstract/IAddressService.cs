using FluentValidation;
using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.AddressModels.UpdateModels;
using UniversityProgram.BLL.Models.AddressModels.ViewModels;

namespace UniversityProgram.BLL.Services.AddressService.Abstract
{
    public interface IAddressService
    {
        public Task AddAsync(AddressAddModel model, IValidator<AddressAddModel> validator, CancellationToken token = default);
        public Task<IEnumerable<AddressModel>> GetAllAsync(CancellationToken token = default);
        public Task<AddressModel> GetByIdAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, AddressUpdateModel model, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
