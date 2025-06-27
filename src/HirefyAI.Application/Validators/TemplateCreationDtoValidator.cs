using DataTransferObjects.Templates;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class TemplateCreationDtoValidator : AbstractValidator<TemplateCreationDto>
    {
        public TemplateCreationDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(300);
        }
    }
}
