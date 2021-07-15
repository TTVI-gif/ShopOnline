using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Detail()
        {
            return View();
        }
        
        public IActionResult Category()
        {
            return View();
        }
    }
}
