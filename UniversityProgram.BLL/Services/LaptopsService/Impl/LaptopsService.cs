using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Map;
using UniversityProgram.BLL.Models.LaptopModels.AddModels;
using UniversityProgram.BLL.Models.LaptopModels.UpdateModels;
using UniversityProgram.BLL.Models.LaptopModels.ViewModels;
using UniversityProgram.BLL.Services.LaptopsService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Data;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.UnitOfWork.Abstract;

namespace UniversityProgram.BLL.Services.LaptopsService.Impl
{
    public class LaptopsService : ILaptopsService
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LaptopsService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LaptopModel>> GetAllAsync(CancellationToken token)
        {
            var laptops = await _uow.LaptopsRepository.GetAllAsync(token);
            return laptops.Select(e => _mapper.Map<LaptopModel>(e));
        }

        public async Task AddAsync(LaptopAddModel model, IValidator<LaptopAddModel> validator, CancellationToken token)
        {

            ObjectValidator.ThrowIfInvalid(await validator.ValidateAsync(model, token));

            await _uow.LaptopsRepository.AddAsync(_mapper.Map<Laptop>(model), token);
            await _uow.Save(token);
        }

        public async Task<LaptopWithCpuModel> GetCpuAsync(int id, CancellationToken token)
        {
            var laptop = await _uow.LaptopsRepository.GetByIdAsync(id, token);

            ObjectValidator.ThrowIfNull(laptop);

            return laptop!.MapLaptopWithCpuModel()!;
        }

        public async Task AddCpuAsync(int id, int cpuId, CancellationToken token)
        {
            var laptop = await _uow.LaptopsRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(laptop);

            var cpu = await _uow.CpuRepository.GetByIdAsync(cpuId, token);
            ObjectValidator.ThrowIfNull(cpu);

            laptop!.Cpu = cpu;
            _uow.LaptopsRepository.Update(laptop);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var laptop = await _uow.LaptopsRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(laptop);
            _uow.LaptopsRepository.Update(laptop);
            await _uow.Save(token);
        }

        public async Task UpdateAsync(int id, LaptopUpdateModel model, CancellationToken token)
        {
            var laptop = await _uow.LaptopsRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(laptop);

            laptop!.Name = model.Name ?? laptop.Name;
            laptop.Cpu = model.Cpu;

            _uow.LaptopsRepository.Update(laptop);

            await _uow.Save(token);
        }
    }
}
