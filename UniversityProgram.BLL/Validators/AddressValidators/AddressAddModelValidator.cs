using FluentValidation;
using UniversityProgram.BLL.Models.AddressModels.AddModels;

namespace UniversityProgram.BLL.Validators.AddressValidators
{
    public class AddressAddModelValidator : AbstractValidator<AddressAddModel>
    {
        public AddressAddModelValidator()
        {
            RuleFor(e => e.Street).NotEmpty();
            RuleFor(e => e.City).NotEmpty();
            RuleFor(e => e.Country).NotEmpty();
        }
    }
}
