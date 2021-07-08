using ShopOnline.Data.EF;
using ShopOnline.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Application.Catalog.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly EshopDbContext _context;

        public CategoryService(EshopDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriesViewModel>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoriesViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
