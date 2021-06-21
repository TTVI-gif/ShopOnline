using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    }
}
