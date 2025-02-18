using FluentValidation;
using UniversityProgram.BLL.Models.StudentModels.AddModels;

namespace UniversityProgram.BLL.Validators.StudentValidators
{
    public class StudentAddModelValidator : AbstractValidator<StudentAddModel>
    {
        public StudentAddModelValidator()
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Name).NotEmpty().MinimumLength(3);
        }
    }
}
