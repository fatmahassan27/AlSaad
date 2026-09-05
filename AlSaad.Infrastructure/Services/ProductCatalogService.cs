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
     public class ProductCatalogService :IProductCatalogService
    {
        private readonly IDaftraApiClient _daftraApiClient;

        public ProductCatalogService(IDaftraApiClient daftraApiClient)
        {
            _daftraApiClient = daftraApiClient;
        }

        public async Task<PagedResult<ProductDto>> GetProductsAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default)
        {
            var response = await _daftraApiClient.GetProductsAsync(page, limit, cancellationToken);

            return new PagedResult<ProductDto>
            {
                Items = response.Data.Select(x => MapToDto(x.Product)).ToList(),
                Page = response.Pagination?.Page ?? page,
                PageCount = response.Pagination?.PageCount ?? 1,
                TotalResults = response.Pagination?.TotalResults ?? response.Data.Count
            };
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _daftraApiClient.GetProductByIdAsync(id, cancellationToken);
            return response is null ? null : MapToDto(response.Data.Product);
        }

        private static ProductDto MapToDto(DaftraProduct product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.UnitPrice??0,
            Brand = product.Brand,
            Category = product.ProductCategory.FirstOrDefault()?.Name ?? product.Category,
            Code = product.ProductCode,
            Barcode = product.Barcode,
            InStock = product.StockBalance > 0,
            StockQuantity = product.StockBalance,
            IsActive = product.Status == 0
        };

      
    }
}
