using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.ApiIntegration;
using ShopOnline.Utilities.Constants;
using ShopOnline.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public CartController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            int quantity = 1;
            if (currentCart.Any(x => x.ProductId == id))
            {
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            }

            var cartItem = new CartItemViewModel()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Quantity = quantity,
                Price = product.Price
            };

            currentCart.Add(cartItem);

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        [HttpGet]
        public  IActionResult GetListItem()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            return Ok(currentCart);
        }
    }
}
