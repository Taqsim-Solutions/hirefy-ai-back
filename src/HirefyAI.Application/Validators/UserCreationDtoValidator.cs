using DataTransferObjects.Users;
using FluentValidation;

namespace HirefyAI.Application.Validators
{
    public class UserCreationDtoValidator : AbstractValidator<UserCreationDto>
    {
        public UserCreationDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
