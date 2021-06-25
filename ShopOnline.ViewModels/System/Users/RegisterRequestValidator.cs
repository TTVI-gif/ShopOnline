using FluentValidation;
using System;

namespace ShopOnline.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.firstName).NotEmpty().WithMessage("First name is required").MaximumLength(200)
                .WithMessage("First name can not over 200 character.");
            RuleFor(x => x.lastName).NotEmpty().WithMessage("last name is required").MaximumLength(200)
                .WithMessage("last name can not over 200 character.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format no match");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

           // RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.PassWord != request.ConfirmPassWord)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
