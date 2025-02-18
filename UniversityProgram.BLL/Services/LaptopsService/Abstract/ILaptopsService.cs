using FluentValidation;
using UniversityProgram.BLL.Models.LaptopModels.AddModels;
using UniversityProgram.BLL.Models.LaptopModels.UpdateModels;
using UniversityProgram.BLL.Models.LaptopModels.ViewModels;

namespace UniversityProgram.BLL.Services.LaptopsService.Abstract
{
    public interface ILaptopsService
    {
        public Task<IEnumerable<LaptopModel>> GetAllAsync(CancellationToken token);
        public Task AddAsync(LaptopAddModel model, IValidator<LaptopAddModel> validator, CancellationToken token);
        public Task<LaptopWithCpuModel> GetCpuAsync(int id, CancellationToken token);
        public Task AddCpuAsync(int id, int cpuId, CancellationToken token);
        public Task DeleteAsync(int id, CancellationToken token);
        public Task UpdateAsync(int id, LaptopUpdateModel model, CancellationToken token);
    }
}
