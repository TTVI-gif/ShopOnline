using ShopOnline.ViewModels.Catalog.Categories;
using ShopOnline.ViewModels.Catalog.ProductImages;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Application.Catalog
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductViewModel> GetbyId(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string laguageId, GetPublicProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> getImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductViewModel>> GetFeatureProduct(string languageId, int take);
    }
}
