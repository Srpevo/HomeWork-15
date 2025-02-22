using UniversityProgram.BLL.Models.CpuModels.AddModels;
using UniversityProgram.BLL.Models.CpuModels.ViewModels;
using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Profiles
{
    public static class CpuMap
    {
        public static Cpu Map(this CpuAddModel model)
        {
            return new Cpu
            {
                Name = model.Name
            };
        }

        public static CpuModel Map(this Cpu cpu)
        {
            return new CpuModel
            {
                Id = cpu.Id,
                Name = cpu.Name

            };
        }
    }
}
