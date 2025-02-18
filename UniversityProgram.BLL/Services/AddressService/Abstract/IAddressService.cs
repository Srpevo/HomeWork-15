using FluentValidation;
using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.AddressModels.UpdateModels;
using UniversityProgram.BLL.Models.AddressModels.ViewModels;

namespace UniversityProgram.BLL.Services.AddressService.Abstract
{
    public interface IAddressService
    {
        public Task AddAsync(AddressAddModel model, IValidator<AddressAddModel> validator, CancellationToken token);
        public Task<IEnumerable<AddressModel>> GetAllAsync(CancellationToken token);
        public Task<AddressModel> GetByIdAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, AddressUpdateModel model, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
    }
}
