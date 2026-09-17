using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IUnitTemplateService
    {
        Task<PagedResult<UnitTemplateDto>> GetUnitTemplatesAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<UnitTemplateDto?> GetUnitTemplateByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
