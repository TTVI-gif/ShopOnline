using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShopOnline.AdminApp.Services;
using ShopOnline.Utilities.Constants;
using ShopOnline.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public ProductController(IConfiguration configuration, IProductApiClient productApiClient)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetProductPagingRequest()
            {
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetAll(request);
            ViewBag.keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMeg = TempData["result"];
            }
            return View(data);
        }
/*
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.(request);
            if (result.IsSuccess)
            {
                TempData["result"] = "Thêm người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }*/
    }
}
