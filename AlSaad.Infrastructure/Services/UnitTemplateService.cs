using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.Services
{
    public class UnitTemplateService : IUnitTemplateService
    {
        private readonly IDaftraUnitTemplateClient _daftraUnitTemplateClient;

        public UnitTemplateService(IDaftraUnitTemplateClient daftraUnitTemplateClient)
        {
            _daftraUnitTemplateClient = daftraUnitTemplateClient;
        }
        public async Task<PagedResult<UnitTemplateDto>> GetUnitTemplatesAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            var response = await _daftraUnitTemplateClient.GetUnitTemplatesAsync(page, cancellationToken);

            return new PagedResult<UnitTemplateDto>
            {
                Items = response.Data.Select(MapToDto).ToList(),
                Page = response.CurrentPage,
                PageCount = response.LastPage,
                TotalResults = response.Total
            };
        }
        public async Task<UnitTemplateDto?> GetUnitTemplateByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var template = await _daftraUnitTemplateClient.GetUnitTemplateByIdAsync(id, cancellationToken);
            return template is null ? null : MapToDto(template);
        }
        private static UnitTemplateDto MapToDto(DaftraUnitTemplate template) => new()
        {
            Id = template.Id,
            TemplateName = template.TemplateName,
            IsActive = template.Active == 1,
            MainUnitName = template.MainUnitName,
            UnitSmallName = template.UnitSmallName,
            UnitFactors = template.UnitTemplatesUnitFactors?.Select(f => new UnitFactorDto
            {
                Id = f.Id,
                FactorName = f.FactorName,
                Factor = f.Factor,
                SmallName = f.SmallName
            }).ToList() ?? new List<UnitFactorDto>()
        };
    }
}
