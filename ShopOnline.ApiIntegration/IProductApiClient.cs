using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetAll(GetProductPagingRequest request);
        Task<bool> Create(ProductCreateRequest request);
        Task<ProductViewModel> GetById(int id, string languageId);

    }
}
