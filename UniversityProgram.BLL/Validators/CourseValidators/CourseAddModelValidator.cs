using FluentValidation;
using UniversityProgram.BLL.Models.CourseModels.AddModels;

namespace UniversityProgram.BLL.Validators.CourseValidators
{
    public class CourseAddModelValidator : AbstractValidator<CourseAddModel>
    {
        public CourseAddModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MaximumLength(100);
            RuleFor(e => e.Fee).NotEmpty().GreaterThan(0);
        }
    }
}
