using FluentValidation;
using HirefyAI.Application.DataTransferObjects.Auth;

namespace HirefyAI.Application.Validators.Auth
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email bo'sh bo'lmasligi kerak.")
                .EmailAddress().WithMessage("Noto‘g‘ri email formati.");
        }
    }
}
