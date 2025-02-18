using UniversityProgram.BLL.Models.CpuModels.AddModels;

namespace UniversityProgram.BLL.Models.LaptopModels.AddModels
{
    public class LaptopAddModel
    {
        public string Name { get; set; } = default!;

        public CpuAddModel? Cpu { get; set; }
    }
}
