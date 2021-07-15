using ShopOnline.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.Application.Catalog.Category
{
    public interface ICategoryService
    {
        Task<List<CategoriesViewModel>> GetAll(string languageId);

        Task<CategoriesViewModel> GetById(string languageId, int id);
    }
}
