using AlSaad.Application.Common.Exceptions;
using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [HttpGet("brands")]
        public async Task<IActionResult> GetDistinctBrands(CancellationToken cancellationToken)
        {
            var brands = await _productCatalogService.GetDistinctBrandsAsync(cancellationToken);
            return Ok(brands);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto ProductDto, CancellationToken cancellationToken)
        {
            try
            {
                var id = await _productCatalogService.CreateProductAsync(ProductDto, cancellationToken);
                return CreatedAtAction(nameof(GetProductById), new { id }, new { id });
            }
            catch (ExternalServiceValidationException ex) when (ex.IsDuplicate)
            {
                return Conflict(new { message = "Existing Product", existingId = ex.ExistingId });
            }
            catch (ExternalServiceValidationException ex)
            {
                return BadRequest(new { message = "Daftra Rejected information", errors = ex.Errors });
            }
        }
        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var updated = await _productCatalogService.UpdateProductAsync(id, dto, cancellationToken);
                return updated ? Ok("successful") : NotFound();
            }
            catch (ExternalServiceValidationException ex)
            {
                return BadRequest(new { message = "Daftra Rejected Information", errors = ex.Errors });
            }
        }
        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                var deleted = await _productCatalogService.DeleteProductAsync(id, cancellationToken);
                return deleted ? Ok("Product has been deleted") : NotFound();
            }
            catch (ExternalServiceValidationException ex)
            {
                return Conflict(new
                {
                    message = ex.Errors.FirstOrDefault() ?? "This Product Can't be Removed",
                    errors = ex.Errors
                });
            }
        }
    }
}
