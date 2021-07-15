using Microsoft.AspNetCore.Mvc;
using ShopOnline.ApiIntegration;
using System.Globalization;
using System.Threading.Tasks;

namespace ShopOnline.WebApp.Controllers.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public SidebarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(items);
        }
    }
}
