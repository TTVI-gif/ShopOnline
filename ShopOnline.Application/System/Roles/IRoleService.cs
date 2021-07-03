using ShopOnline.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}
