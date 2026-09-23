using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("site_id")]
        public string? SiteId { get; set; }

        [JsonPropertyName("staff_id")]
        public string? StaffId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal? UnitPrice { get; set; }

        [JsonPropertyName("default_quantity")]
        public decimal? DefaultQuantity { get; set; }

        [JsonPropertyName("tax1")]
        public decimal? Tax1 { get; set; }

        [JsonPropertyName("tax2")]
        public decimal? Tax2 { get; set; }

        [JsonPropertyName("purchasing_tax1")]
        public decimal? PurchasingTax1 { get; set; }

        [JsonPropertyName("purchasing_tax2")]
        public decimal? PurchasingTax2 { get; set; }

        [JsonPropertyName("supplier_id")]
        public string? SupplierId { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("brand_id")]
        public string? BrandId { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        [JsonPropertyName("buy_price")]
        public decimal? BuyPrice { get; set; }

        [JsonPropertyName("product_code")]
        public string? ProductCode { get; set; }

        [JsonPropertyName("supplier_code")]
        public string? SupplierCode { get; set; }

        [JsonPropertyName("track_stock")]
        public string? TrackStock { get; set; }

        [JsonPropertyName("tracking_type")]
        public string? TrackingType { get; set; }

        [JsonPropertyName("stock_balance")]
        public decimal StockBalance { get; set; }

        [JsonPropertyName("low_stock_thershold")]
        public decimal? LowStockThreshold { get; set; }

        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [JsonPropertyName("deactivate")]
        public string? Deactivate { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("created")]
        public string? Created { get; set; }

        [JsonPropertyName("modified")]
        public string? Modified { get; set; }

        [JsonPropertyName("follow_up_status")]
        public string? FollowUpStatus { get; set; }

        [JsonPropertyName("updated_price")]
        public string? UpdatedPrice { get; set; }

        [JsonPropertyName("average_price")]
        public decimal? AveragePrice { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("raw_store_id")]
        public string? RawStoreId { get; set; }

        [JsonPropertyName("class")]
        public string? Class { get; set; }

        [JsonPropertyName("extra_details")]
        public string? ExtraDetails { get; set; }

        [JsonPropertyName("minimum_price")]
        public decimal? MinimumPrice { get; set; }

        [JsonPropertyName("profit_margin")]
        public decimal? ProfitMargin { get; set; }

        [JsonPropertyName("discount")]
        public decimal? Discount { get; set; }

        [JsonPropertyName("discout_type")]
        public string? DiscoutType { get; set; }

        [JsonPropertyName("duration_minutes")]
        public int? DurationMinutes { get; set; }

        [JsonPropertyName("availabe_online")]
        public string? AvailabeOnline { get; set; }

        [JsonPropertyName("source_type")]
        public string? SourceType { get; set; }

        [JsonPropertyName("source_id")]
        public string? SourceId { get; set; }

        [JsonPropertyName("branch_id")]
        public string? BranchId { get; set; }

        [JsonPropertyName("is_featured")]
        public string? IsFeatured { get; set; }

        [JsonPropertyName("bundle_type")]
        public string? BundleType { get; set; }

        [JsonPropertyName("item_group_id")]
        public string? ItemGroupId { get; set; }

        [JsonPropertyName("display_order")]
        public int? DisplayOrder { get; set; }

        [JsonPropertyName("product_store_balance")]
        public decimal? ProductStoreBalance { get; set; }

        [JsonPropertyName("bundle_final_cost")]
        public decimal? BundleFinalCost { get; set; }


        // Daftra can return this field as different JSON shapes
        // such as [] or {}.
        // JsonElement allows us to receive any valid JSON shape.
        [JsonPropertyName("productPendingQTY")]
        public JsonElement? ProductPendingQTY { get; set; }


        // Daftra normally returns:
        // {
        //   "1": 0,
        //   "2": 10
        // }
        //
        // But sometimes it can return [].
        // FlexibleDictionaryConverter handles both cases.
        [JsonPropertyName("productAvailableQTY")]
        public Dictionary<string, decimal>? ProductAvailableQTY { get; set; }


        [JsonPropertyName("ProductCategory")]
        public List<DaftraProductCategory>? ProductCategory { get; set; }


        // Can have different shapes, so JsonElement is safer.
        [JsonPropertyName("ProductStock")]
        public JsonElement? ProductStock { get; set; }


        // Temporarily kept as JsonElement because
        // Daftra may return different structures.
        [JsonPropertyName("ProductImage")]
        public JsonElement? ProductImage { get; set; }

        [JsonPropertyName("ProductImageS3")]
        public JsonElement? ProductImageS3 { get; set; }
    }
}
