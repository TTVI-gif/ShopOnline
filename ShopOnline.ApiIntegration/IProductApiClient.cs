using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetAll(GetProductPagingRequest request);
        Task<bool> Create(ProductCreateRequest request);
        Task<ProductViewModel> GetById(int id, string languageId);
        Task<List<ProductViewModel>> GetFeatureProduct(string languageId, int take);
        Task<List<ProductViewModel>> GetaLatestProduct(string languageId, int take);
        Task<bool> UpdateProduct(ProductUpdateRequest request);
        Task<bool> Delete(int productId);
    }
}
