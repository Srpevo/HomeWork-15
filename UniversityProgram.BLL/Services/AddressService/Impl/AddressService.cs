using AutoMapper;
using FluentValidation;
using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.AddressModels.UpdateModels;
using UniversityProgram.BLL.Models.AddressModels.ViewModels;
using UniversityProgram.BLL.Services.AddressService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Domain.BaseRepositories;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Services.AddressService.Impl
{
    public class AddressService : IAddressService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddressService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(AddressAddModel model, IValidator<AddressAddModel> validator, CancellationToken token)
        {
            
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _uow.AddressRepository.AddAsync(_mapper.Map<Address>(model), token);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var address = await _uow.AddressRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(address);
            _uow.AddressRepository.Delete(address, token);
            await _uow.Save(token);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAsync(CancellationToken token)
        {
            var addresses = await _uow.AddressRepository.GetAllAsync(token);
            return addresses.Select(e => _mapper.Map<AddressModel>(e));
        }

        public async Task<AddressModel> GetByIdAsync(int id, CancellationToken token)
        {
            var address = await _uow.AddressRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(address);
            return _mapper.Map<AddressModel>(address);
        }

        public async Task UpdateAsync(int id, AddressUpdateModel model, CancellationToken token)
        {
            var address = await _uow.AddressRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(address);

            address!.Street = model.Street ?? address.Street;
            address.City = model.City ?? address.City;
            address.Country = model.Country ?? address.Country;

            _uow.AddressRepository.Update(address, token);

            await _uow.Save(token);
        }
    }
}
