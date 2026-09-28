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
     public class ProductService : IProductService
    {
        private readonly IDaftraProductClient _daftraApiClient;

        public ProductService(IDaftraProductClient daftraApiClient)
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
        public async Task<List<BrandLookupDto>> GetDistinctBrandsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _daftraApiClient.GetProductsAsync(page: 1, limit: 200, cancellationToken);

            return response.Data
                .Select(x => x.Product)
                .Where(p => !string.IsNullOrWhiteSpace(p.Brand) && !string.IsNullOrWhiteSpace(p.BrandId))
                .GroupBy(p => p.BrandId)
                .Select(g => new BrandLookupDto
                {
                    Id = g.Key!,
                    Name = g.First().Brand!
                })
                .OrderBy(b => b.Name)
                .ToList();
        }

        private static ProductDto MapToDto(DaftraProduct product) => new()
        {
            Id = product.Id,

            SiteId = product.SiteId,
            StaffId = product.StaffId,

            Name = product.Name,
            Description = product.Description,

            UnitPrice = product.UnitPrice,
            DefaultQuantity = product.DefaultQuantity,

            Tax1 = product.Tax1,
            Tax2 = product.Tax2,

            PurchasingTax1 = product.PurchasingTax1,
            PurchasingTax2 = product.PurchasingTax2,

            SupplierId = product.SupplierId,

            Brand = product.Brand,
            BrandId = product.BrandId,

            Category = product.ProductCategory?.FirstOrDefault()?.Name ?? product.Category,
            Tags = product.Tags,

            BuyPrice = product.BuyPrice,

            ProductCode = product.ProductCode,
            SupplierCode = product.SupplierCode,

            TrackStock = product.TrackStock,
            TrackingType = product.TrackingType,

            StockBalance = product.StockBalance,
            LowStockThreshold = product.LowStockThreshold,

            Barcode = product.Barcode,

            Notes = product.Notes,

            Deactivate = product.Deactivate,
            Status = product.Status,

            Created = DateTime.TryParse(product.Created, out var created) ? created : null,
            Modified = DateTime.TryParse(product.Modified, out var modified) ? modified : null,

            FollowUpStatus = product.FollowUpStatus,

            UpdatedPrice = product.UpdatedPrice,
            AveragePrice = product.AveragePrice,

            Type = product.Type,

            RawStoreId = product.RawStoreId,

            Class = product.Class,
            ExtraDetails = product.ExtraDetails,

            MinimumPrice = product.MinimumPrice,
            ProfitMargin = product.ProfitMargin,

            Discount = product.Discount,
            DiscoutType = product.DiscoutType,

            DurationMinutes = product.DurationMinutes,

            AvailabeOnline = product.AvailabeOnline,

            SourceType = product.SourceType,
            SourceId = product.SourceId,

            BranchId = product.BranchId,

            IsFeatured = product.IsFeatured,

            BundleType = product.BundleType,
            ItemGroupId = product.ItemGroupId,

            DisplayOrder = product.DisplayOrder,

            ProductStoreBalance = product.ProductStoreBalance,

            BundleFinalCost = product.BundleFinalCost,

            ProductPendingQTY = product.ProductPendingQTY,

            ProductAvailableQTY = product.ProductAvailableQTY,

            ProductCategory = product.ProductCategory?.Select(static category => MapCategoryToDto(category)).ToList()?? new List<ProductCategoryDto>(),
            ProductStock = new List<ProductStockDto>()
            // مؤقتًا لحد ما نعمل DTOs الخاصة بالصور
            // ProductImage = ...,
            // ProductImageS3 = ...,


        };

        private static ProductCategoryDto MapCategoryToDto(DaftraProductCategory category) => new()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CategoryType = category.CategoryType,
            ParentId = category.ParentId,
            Created = DateTime.TryParse(category.Created, out var created) ? created : null,
            Modified = DateTime.TryParse(category.Modified, out var modified) ? modified : null,
            Image = category.Image,
            MacAddress = category.MacAddress,
            BranchId = category.BranchId,
            Status = category.Status
        };
    }
}
