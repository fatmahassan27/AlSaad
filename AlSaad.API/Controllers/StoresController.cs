using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores(
            [FromQuery] int page = 1,
            [FromQuery] int limit = 20,
            CancellationToken cancellationToken = default)
        {
            var result = await _storeService.GetStoresAsync(page, limit, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStoreById(int id, CancellationToken cancellationToken)
        {
            var store = await _storeService.GetStoreByIdAsync(id, cancellationToken);
            return store is null ? NotFound() : Ok(store);
        }
    }
}
