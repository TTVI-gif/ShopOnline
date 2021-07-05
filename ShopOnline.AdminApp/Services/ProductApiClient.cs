using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

       /* public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
            return await GetAsync<ApiResult<bool>>();
        }*/

        public async Task<PagedResult<ProductViewModel>> GetAll(GetProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductViewModel>>(
                $"/api/products/paging?pageIndex= {request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.KeyWord}" +
                $"&languageId={ request.LanguageId}");
            return data;
        }

       
    }
}
