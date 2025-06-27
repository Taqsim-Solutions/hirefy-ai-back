using DataTransferObjects.Experiences;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class ExperienceCreationDtoValidator : AbstractValidator<ExperienceCreationDto>
    {
        public ExperienceCreationDtoValidator()
        {
            RuleFor(x => x.JobTitle).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(100);
            //RuleFor(x => x.StartDate).LessThanOrEqualTo(DateOnly);
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(x => x.StartDate)
                                   .When(x => x.EndDate.HasValue);
            RuleFor(x => x.Summary).MaximumLength(300);
            RuleFor(x => x.ResumeId).GreaterThan(0);
        }
    }
}
