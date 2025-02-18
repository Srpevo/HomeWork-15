using UniversityProgram.BLL.Models.CpuModels.ViewModels;

namespace UniversityProgram.BLL.Models.LaptopModels.ViewModels
{
    public class LaptopModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public CpuModel? Cpu { get; set; } = default!;
    }
}
