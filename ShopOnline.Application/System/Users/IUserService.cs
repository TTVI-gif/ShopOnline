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
        Task<ApiResult<string>> AuthenCate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
