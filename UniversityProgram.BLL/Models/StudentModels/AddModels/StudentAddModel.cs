using UniversityProgram.BLL.Models.AddressModels.AddModels;
using UniversityProgram.BLL.Models.LaptopModels.AddModels;

namespace UniversityProgram.BLL.Models.StudentModels.AddModels
{
    public class StudentAddModel
    {
        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public LaptopAddModel? Laptop { get; set; }

        public AddressAddModel? Address { get; set; }
    }
}
