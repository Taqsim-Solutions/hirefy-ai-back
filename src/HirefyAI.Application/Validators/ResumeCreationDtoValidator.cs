using DataTransferObjects.Resumes;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class ResumeCreationDtoValidator : AbstractValidator<ResumeCreationDto>
    {
        public ResumeCreationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.JobTitle).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.TemplateId).GreaterThan(0);

            RuleForEach(x => x.Skills).SetValidator(new SkillCreationDtoValidator());
            RuleForEach(x => x.Educations).SetValidator(new EducationCreationDtoValidator());
            RuleForEach(x => x.Experiences).SetValidator(new ExperienceCreationDtoValidator());
        }
    }
}
