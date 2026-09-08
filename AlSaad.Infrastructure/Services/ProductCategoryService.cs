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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IDaftraProductCategoryClient _daftraProductCategoryClient;

        public ProductCategoryService(IDaftraProductCategoryClient daftraProductCategoryClient)
        {
            _daftraProductCategoryClient = daftraProductCategoryClient;
        }
        public async Task<PagedResult<ProductCategoryDto>> GetCategoriesAsync(int page = 1, int limit = 20, int? parentId = null, CancellationToken cancellationToken = default)
        {
            var response = await _daftraProductCategoryClient.GetCategoriesAsync(page, limit, parentId, cancellationToken);

            return new PagedResult<ProductCategoryDto>
            {
                Items = response.Data.Select(x => MapToDto(x.ProductCategory)).ToList(),
                Page = response.Pagination?.Page ?? page,
                PageCount = response.Pagination?.PageCount ?? 1,
                TotalResults = response.Pagination?.TotalResults ?? response.Data.Count
            };
        }
        public async Task<ProductCategoryDto?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _daftraProductCategoryClient.GetCategoryByIdAsync(id, cancellationToken);
            return response is null ? null : MapToDto(response.Data.Category);
        }
        private static ProductCategoryDto MapToDto(DaftraProductCategory category) => new()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            ParentId = category.ParentId ?? 0,
            ParentCategoryName = category.ParentCategory?.Name,
            ImageUrl = category.Image
        };
    }
}
