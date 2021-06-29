using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopOnline.ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Họ")]
        public string firstName { get; set; }
        [Display(Name = "Tên")]
        public string lastName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string phoneNumber { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }
    }
}
