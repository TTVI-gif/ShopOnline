using Microsoft.AspNetCore.Mvc;
using ShopOnline.ApiIntegration;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.WebApp.Models;
using System.Threading.Tasks;

namespace ShopOnline.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public IActionResult Detail()
        {
            return View();
        }
        
        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products = await _productApiClient.GetAll(new GetProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = page,
                LanguageId = culture,
                PageSize = 10

            }); ;
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            }) ;
        }
    }
}
