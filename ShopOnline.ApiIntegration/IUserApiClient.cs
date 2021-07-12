using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Autheticate(LoginRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
