using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UniversityProgram.BLL.Map;
using UniversityProgram.BLL.Models.CpuModels.AddModels;
using UniversityProgram.BLL.Models.CpuModels.UpdateModels;
using UniversityProgram.BLL.Models.CpuModels.ViewModels;
using UniversityProgram.BLL.Services.CpuService.Abstract;
using UniversityProgram.BLL.Validators.ObjectValidator;
using UniversityProgram.Data;
using UniversityProgram.Data.Entities;
using UniversityProgram.Data.Repositories.UnitOfWork.Abstract;

namespace UniversityProgram.BLL.Services.CpuService.Impl
{
    public class CpuService : ICpuService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CpuService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(CpuAddModel model, IValidator<CpuAddModel> validator, CancellationToken token)
        {
            ObjectValidator.ThrowIfInvalid(validator.Validate(model));
            await _uow.CpuRepository.AddAsync(_mapper.Map<Cpu>(model), token);
            await _uow.Save(token);
        }

        public async Task DeleteAsync(int id, CancellationToken token)
        {
            var cpu = await _uow.CpuRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(cpu);
            _uow.CpuRepository.Delete(cpu, token);
            await _uow.Save(token);
        }

        public async Task<IEnumerable<CpuModel>> GetAllAsync(CancellationToken token)
        {
            var cpus = await _uow.CpuRepository.GetAllAsync(token);
            return cpus.Select(cpu => _mapper.Map<CpuModel>(cpu));
        }

        public async Task<CpuModel> GetByIdAsync(int id, CancellationToken token)
        {
            var cpu = await _uow.CpuRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(cpu);
            return _mapper.Map<CpuModel>(cpu);
        }

        public async Task UpdateAsync(int id, CpuUpdateModel model, CancellationToken token)
        {
            var cpu = await _uow.CpuRepository.GetByIdAsync(id, token);
            ObjectValidator.ThrowIfNull(cpu);
            cpu!.Name = model.Name ?? cpu.Name;

            _uow.CpuRepository.Update(cpu, token);

            await _uow.Save(token);
        }
    }
}
