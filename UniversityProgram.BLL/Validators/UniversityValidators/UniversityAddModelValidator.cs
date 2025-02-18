using FluentValidation;
using UniversityProgram.BLL.Models.UniversityModels.AddModels;

namespace UniversityProgram.BLL.Validators.UniversityValidators
{
    public class UniversityAddModelValidator : AbstractValidator<UniversityAddModel>
    {
        public UniversityAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
