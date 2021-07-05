using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopOnline.Data.EF;
using ShopOnline.ViewModels.Common;
using ShopOnline.ViewModels.System.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Application.System.Language
{
    public class LanguageService : ILanguageService
    {
        private readonly EshopDbContext _context;
        private readonly IConfiguration _config;
        public LanguageService(IConfiguration config, EshopDbContext context)
        {
            _context = context;
            _config = config;
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageViewModel>>(languages);
        }
    }
}
