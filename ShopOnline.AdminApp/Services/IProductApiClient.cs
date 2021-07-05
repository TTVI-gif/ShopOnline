using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetAll(GetProductPagingRequest request);
        //Task<ApiResult<bool>> Create(ProductCreateRequest request);
    }
}
