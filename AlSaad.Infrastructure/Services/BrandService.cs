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
    public class BrandService : IBrandService
    {
        private readonly IDaftraBrandClient _daftraBrandClient;

        public BrandService(IDaftraBrandClient daftraBrandClient)
        {
            _daftraBrandClient = daftraBrandClient;
        }
        public async Task<PagedResult<BrandDto>> GetBrandsAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            var response = await _daftraBrandClient.GetBrandsAsync(page, cancellationToken);

            return new PagedResult<BrandDto>
            {
                Items = response.Data.Select(MapToDto).ToList(),
                Page = response.CurrentPage,
                PageCount = response.LastPage,
                TotalResults = response.Total
            };
        }
        public async Task<BrandDto?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var brand = await _daftraBrandClient.GetBrandByIdAsync(id, cancellationToken);
            return brand is null ? null : MapToDto(brand);
        }

        private static BrandDto MapToDto(DaftraBrand brand) => new()
        {
            Id = brand.Id,
            Name = brand.Name,
            Created = DateTime.TryParse(brand.Created, out var created) ? created : null,
            Modified = DateTime.TryParse(brand.Modified, out var modified) ? modified : null
        };
    }
}
