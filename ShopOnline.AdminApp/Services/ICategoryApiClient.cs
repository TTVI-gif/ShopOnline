using ShopOnline.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoriesViewModel>> GetAll(string languageId);
    }
}
