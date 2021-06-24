using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.System.Users
{
    public interface IUserService
    {
        Task<string> AuthenCate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request); 
    }
}
