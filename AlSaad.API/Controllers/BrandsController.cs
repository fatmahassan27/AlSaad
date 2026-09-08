using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands([FromQuery] int page = 1, CancellationToken cancellationToken = default)
        {
            var result = await _brandService.GetBrandsAsync(page, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBrandById(int id, CancellationToken cancellationToken)
        {
            var brand = await _brandService.GetBrandByIdAsync(id, cancellationToken);
            return brand is null ? NotFound() : Ok(brand);
        }
    }
}
