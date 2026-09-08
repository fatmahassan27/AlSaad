using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IBrandService
    {
        Task<PagedResult<BrandDto>> GetBrandsAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<BrandDto?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
