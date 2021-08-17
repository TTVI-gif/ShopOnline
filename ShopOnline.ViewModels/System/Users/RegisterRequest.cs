using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopOnline.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name="Họ")]
        public string firstName { get; set; }
        [Display(Name ="Tên")]
        public string lastName { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }
    }
}
