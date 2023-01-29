using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u)
                .NotNull().WithMessage("Entity is null")
                .NotEmpty().WithMessage("Entity is empty");
            
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(6, 20).WithMessage("Password must be between 6 and 20 characters");
        }
    }
}