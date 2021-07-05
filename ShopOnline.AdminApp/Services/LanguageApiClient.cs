﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Language;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory, 
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {   
            return await GetAsync<ApiResult<List<LanguageViewModel>>>("/api/languages");
        }
    }
}
