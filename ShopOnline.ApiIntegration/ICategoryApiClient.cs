using ShopOnline.ViewModels.Catalog.Categories;
using ShopOnline.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoriesViewModel>> GetAll(string languageId);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
    }
}
