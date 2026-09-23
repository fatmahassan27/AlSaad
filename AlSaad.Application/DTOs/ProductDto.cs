using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string? SiteId { get; set; }

        public string? StaffId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? DefaultQuantity { get; set; }

        public decimal? Tax1 { get; set; }

        public decimal? Tax2 { get; set; }

        public decimal? PurchasingTax1 { get; set; }

        public decimal? PurchasingTax2 { get; set; }

        public string? SupplierId { get; set; }

        public string? Brand { get; set; }

        public string? BrandId { get; set; }

        public string? Category { get; set; }

        public string? Tags { get; set; }

        public decimal? BuyPrice { get; set; }

        public string? ProductCode { get; set; }

        public string? SupplierCode { get; set; }

        public string? TrackStock { get; set; }

        public string? TrackingType { get; set; }

        public decimal? StockBalance { get; set; }

        public decimal? LowStockThreshold { get; set; }

        public string? Barcode { get; set; }

        public string? Notes { get; set; }

        public string? Deactivate { get; set; }

        public string? Status { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? FollowUpStatus { get; set; }

        public string? UpdatedPrice { get; set; }

        public decimal? AveragePrice { get; set; }

        public string? Type { get; set; }

        public string? RawStoreId { get; set; }

        public string? Class { get; set; }

        public string? ExtraDetails { get; set; }

        public decimal? MinimumPrice { get; set; }

        public decimal? ProfitMargin { get; set; }

        public decimal? Discount { get; set; }

        public string? DiscoutType { get; set; }

        public int? DurationMinutes { get; set; }

        public string? AvailabeOnline { get; set; }

        public string? SourceType { get; set; }

        public string? SourceId { get; set; }

        public string? BranchId { get; set; }

        public string? IsFeatured { get; set; }

        public string? BundleType { get; set; }

        public string? ItemGroupId { get; set; }

        public int? DisplayOrder { get; set; }

        public decimal? ProductStoreBalance { get; set; }

        public decimal? BundleFinalCost { get; set; }

        public JsonElement? ProductPendingQTY { get; set; }

        public Dictionary<string, decimal> ProductAvailableQTY { get; set; } = new();

        // public List<ProductImageDto>? ProductImage { get; set; }

        public List<ProductCategoryDto>? ProductCategory { get; set; }

        public List<ProductStockDto>? ProductStock { get; set; }

      //  public List<ProductImageS3Dto>? ProductImageS3 { get; set; }
    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int TotalResults { get; set; }
    }
}
