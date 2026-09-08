using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IProductCategoryService
    {
        Task<PagedResult<ProductCategoryDto>> GetCategoriesAsync(int page = 1, int limit = 20, int? parentId = null, CancellationToken cancellationToken = default);
        Task<ProductCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
