using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Entiiies
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Dob { get; set; }
        public List<Carts> Carts { get; set; }
        public List<Order> orders { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
