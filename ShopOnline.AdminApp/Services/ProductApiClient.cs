using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopOnline.Utilities.Constants;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.ViewModels.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public ProductApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<bool> Create(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnaiImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnaiImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnaiImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnaiImage", request.ThumbnaiImage.FileName);
            }

            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Description.ToString()), "description");

            requestContent.Add(new StringContent(request.Details.ToString()), "details");
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/products/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ProductViewModel>> GetAll(GetProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductViewModel>>(
                $"/api/products/paging?pageIndex= {request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.KeyWord}" +
                $"&languageId={ request.LanguageId}" +
                $"&categoryId={request.CategoryId}");
            return data;
        }


    }
}
