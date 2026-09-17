using AlSaad.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlSaad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitTemplatesController : ControllerBase
    {
        private readonly IUnitTemplateService _unitTemplateService;

        public UnitTemplatesController(IUnitTemplateService unitTemplateService)
        {
            _unitTemplateService = unitTemplateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUnitTemplates([FromQuery] int page = 1, CancellationToken cancellationToken = default)
        {
            var result = await _unitTemplateService.GetUnitTemplatesAsync(page, cancellationToken);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUnitTemplateById(int id, CancellationToken cancellationToken)
        {
            var template = await _unitTemplateService.GetUnitTemplateByIdAsync(id, cancellationToken);
            return template is null ? NotFound() : Ok(template);
        }
        
    }
}
