using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Catalog.Products;
using ShopOnline.ViewModels.Catalog.Categories;
using ShopOnline.ViewModels.Catalog.ProductImages;
using ShopOnline.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace ShopOnline.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetProductPagingRequest request)
        {
            var product = await _productService.GetAllPaging(request);
            return Ok(product);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _productService.GetbyId(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.Create(request);
            if (result == 0)
                return BadRequest();
            var product = await _productService.GetbyId(result, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = result }, product);
        }

        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute]int productId,[FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
            var result = await _productService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.Delete(productId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccess = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccess) return Ok();
            return BadRequest();
        }

        [HttpGet("{productId}/{images}/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest($"Cannot find image with id {imageId}");
            return Ok(image);
        }

        [HttpPost("{productId}/{image }")]
        public async Task<IActionResult> AddImage(int productId, ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.AddImage(productId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            var image = await _productService.GetImageById(productId);
            return CreatedAtAction(nameof(GetImageById), new { id = result }, image);
        }

        [HttpPut("{productId}/{image}/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}/{image}/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}/categories")]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        [HttpGet("feature/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult>GetFeatureProduct(string languageId, int take)
        {
            var featureProduct = await _productService.GetFeatureProduct(languageId, take);
            return Ok(featureProduct);
        }

        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProduct(string languageId, int take)
        {
            var featureProduct = await _productService.GetFeatureProduct(languageId, take);
            return Ok(featureProduct);
        }
    }
}
