using DataTransferObjects.Skills;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class SkillCreationDtoValidator : AbstractValidator<SkillCreationDto>
    {
        public SkillCreationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.ResumeId).GreaterThan(0);
        }
    }
}
