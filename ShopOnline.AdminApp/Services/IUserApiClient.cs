using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Users;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Autheticate(LoginRequest request);

        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
    }
}
