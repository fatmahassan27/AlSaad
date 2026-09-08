using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] int page = 1,[FromQuery] int limit = 20,[FromQuery] int? parentId = null,
           CancellationToken cancellationToken = default)
        {
            var result = await _productCategoryService.GetCategoriesAsync(page, limit, parentId, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            var category = await _productCategoryService.GetCategoryByIdAsync(id, cancellationToken);
            return category is null ? NotFound() : Ok(category);
        }
    }
}
