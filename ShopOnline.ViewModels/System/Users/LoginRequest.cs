using System.ComponentModel.DataAnnotations;

namespace ShopOnline.ViewModels.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        [ShouldNotContainSingleQuotesValidation(ErrorMessage = "Cannot contain single quotes")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }

    public sealed class ShouldNotContainSingleQuotesValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !value.ToString().Contains("'");
        }
    }
}
