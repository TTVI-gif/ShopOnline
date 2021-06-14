using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime Dob { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
