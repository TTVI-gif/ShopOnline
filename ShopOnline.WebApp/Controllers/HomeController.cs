using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOnline.ApiIntegration;
using ShopOnline.Utilities.Constants;
using ShopOnline.WebApp.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace ShopOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideApiClient _slideApiClient;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiClient _productApiClient;

        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient, IProductApiClient productApiClient)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var viewModel = new HomeViewModel()
            {
                Slides = await _slideApiClient.GetAll(),
                ProductFeature = await _productApiClient.GetFeatureProduct(culture, SystemConstants.ProductSetting.NumbeOfFeatureProduct),
                LatestProduct = await _productApiClient.GetaLatestProduct(culture, SystemConstants.ProductSetting.NumberOfLatestProduct)
            };

            return View(viewModel);
        }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult SetCultureCookie(string cltr, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

        return LocalRedirect(returnUrl);
    }
}
}
