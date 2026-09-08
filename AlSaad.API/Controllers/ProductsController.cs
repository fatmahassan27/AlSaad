using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productCatalogService;

        public ProductsController(IProductService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int page = 1, [FromQuery] int limit = 20, CancellationToken cancellationToken = default)
        {
            var result = await _productCatalogService.GetProductsAsync(page, limit, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await _productCatalogService.GetProductByIdAsync(id, cancellationToken);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
