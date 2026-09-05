using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IProductCatalogService
    {
        Task<PagedResult<ProductDto>> GetProductsAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default);
        Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
