using FluentValidation;
using UniversityProgram.BLL.Models.LibraryModels.AddModels;

namespace UniversityProgram.BLL.Validators.LibraryValidators
{
    public class LibraryAddModelValidator : AbstractValidator<LibraryAddModel>
    {
        public LibraryAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(0);
        }
    }
}
