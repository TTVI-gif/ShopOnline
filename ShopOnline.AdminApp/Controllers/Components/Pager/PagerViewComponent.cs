using Microsoft.AspNetCore.Mvc;
using ShopOnline.ViewModels.Common;
using System.Threading.Tasks;

namespace ShopOnline.AdminApp.Controllers.Components
{
    
        public class PagerViewComponent : ViewComponent
        {
            public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
            {
                return Task.FromResult((IViewComponentResult)View("Default", result));
            }
        }
    
}
