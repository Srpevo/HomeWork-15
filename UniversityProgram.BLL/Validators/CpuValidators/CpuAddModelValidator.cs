using FluentValidation;
using UniversityProgram.BLL.Models.CpuModels.AddModels;

namespace UniversityProgram.BLL.Validators.CpuValidators
{
    public class CpuAddModelValidator : AbstractValidator<CpuAddModel>
    {
        public CpuAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
