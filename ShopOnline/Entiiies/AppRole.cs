using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Entiiies
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
