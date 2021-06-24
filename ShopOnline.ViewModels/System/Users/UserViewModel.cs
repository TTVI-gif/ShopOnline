using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
