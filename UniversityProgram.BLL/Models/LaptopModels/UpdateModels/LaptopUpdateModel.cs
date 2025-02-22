using UniversityProgram.Domain.Entities;

namespace UniversityProgram.BLL.Models.LaptopModels.UpdateModels
{
    public class LaptopUpdateModel
    {
        public string Name { get; set; } = default!;
        public Cpu Cpu { get; set; } = default!;
    }
}
