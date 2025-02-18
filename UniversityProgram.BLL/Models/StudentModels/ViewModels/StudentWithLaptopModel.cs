using UniversityProgram.BLL.Models.LaptopModels.ViewModels;

namespace UniversityProgram.BLL.Models.StudentModels.ViewModels
{
    public class StudentWithLaptopModel : StudentModel
    {
        public LaptopWithCpuModel? Laptop { get; set; }
    }
}
