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

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
