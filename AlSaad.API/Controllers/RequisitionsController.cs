using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionsController : ControllerBase
    {
        private readonly IRequisitionService _requisitionService;

        public RequisitionsController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequisitions(
            [FromQuery] int page = 1,
            [FromQuery] int? storeId = null,
            CancellationToken cancellationToken = default)
        {
            var result = await _requisitionService.GetRequisitionsAsync(page, storeId, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRequisitionById(int id, CancellationToken cancellationToken)
        {
            var requisition = await _requisitionService.GetRequisitionByIdAsync(id, cancellationToken);
            return requisition is null ? NotFound() : Ok(requisition);
        }
    }
}
