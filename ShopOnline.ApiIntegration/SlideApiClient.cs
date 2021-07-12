using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopOnline.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopOnline.ApiIntegration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<SlideViewModel>> GetAll()
        {    
            return await GetListAsync<SlideViewModel>("/api/slides");
        }
    }
}
