using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ShopOnline.AdminApp.Services;
using ShopOnline.Utilities.Constants;
using ShopOnline.ViewModels.Catalog.Products;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        public ProductController(IConfiguration configuration, IProductApiClient productApiClient, 
            ICategoryApiClient categoryApiClient)
        {
            _configuration = configuration;
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword,int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetProductPagingRequest()
            {
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
                
            };
            var data = await _productApiClient.GetAll(request);
            var category = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = category.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });
            ViewBag.keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMeg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _productApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            return View(request);
        }
    }
}
