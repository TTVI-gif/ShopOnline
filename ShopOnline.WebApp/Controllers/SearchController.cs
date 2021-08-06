using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.ApiIntegration;
using ShopOnline.Utilities.Constants;
using ShopOnline.ViewModels.Catalog.Products;
using ShopOnline.WebApp.Models;
using System.Threading.Tasks;


namespace ShopOnline.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        
        public SearchController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, string culture, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetProductPagingRequest()
            {
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = culture,
                CategoryId = categoryId
            };
            var data = await _productApiClient.GetAll(request);
            ViewBag.keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMeg = TempData["result"];
            }
            var viewModel = new HomeViewModel()
            {
                ProductFeature = await _productApiClient.GetFeatureProduct(culture, SystemConstants.ProductSetting.NumbeOfFeatureProduct)
            };
            return View(viewModel);
        }
    }
}
