using UniversityProgram.BLL.Models.AddressModels.ViewModels;

namespace UniversityProgram.BLL.Models.StudentModels.ViewModels
{
    public class StudentWithAddressModel : StudentModel
    {
        public AddressModel? AddressModel { get; set; } = default!;
    }
}
