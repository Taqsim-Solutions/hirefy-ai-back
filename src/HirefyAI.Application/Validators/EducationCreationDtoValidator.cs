using DataTransferObjects.Educations;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class EducationCreationDtoValidator : AbstractValidator<EducationCreationDto>
    {
        public EducationCreationDtoValidator()
        {
            RuleFor(x => x.Degree).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Institution).NotEmpty().MaximumLength(150);
            //RuleFor(x => x.StartDate).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate)
                                   .When(x => x.EndDate.HasValue);
            RuleFor(x => x.Description).MaximumLength(300);
            RuleFor(x => x.ResumeId).GreaterThan(0);
        }
    }
}
