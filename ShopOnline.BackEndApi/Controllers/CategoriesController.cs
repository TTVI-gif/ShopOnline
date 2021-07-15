using Microsoft.AspNetCore.Mvc;
using ShopOnline.Application.Catalog.Category;
using System.Threading.Tasks;

namespace ShopOnline.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var category = await _categoryService.GetAll(languageId);
            return Ok(category);
        }


        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _categoryService.GetById(languageId, id);
            return Ok(category);
        }
    }
}
