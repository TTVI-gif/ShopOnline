using FluentValidation;

namespace ShopOnline.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is requierd").MinimumLength(6)
                .WithMessage("Password is least 6 character");

        }
    }
}
