using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraCreateProductRequest
    {
        [JsonPropertyName("Product")]
        public DaftraCreateProductBody Product { get; set; } = new();
    }
    public class DaftraCreateProductBody
    {
        [JsonPropertyName("name")] 
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("type")] 
        public int? Type { get; set; }
        [JsonPropertyName("product_code")]
        public string? ProductCode { get; set; }
        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
        [JsonPropertyName("unit_price")]
        public decimal? UnitPrice { get; set; }
        [JsonPropertyName("buy_price")]
        public decimal? BuyPrice { get; set; }
        [JsonPropertyName("discount")]
        public decimal? Discount { get; set; }
        [JsonPropertyName("discount_type")]
        public int? DiscountType { get; set; }
        [JsonPropertyName("brand")] 
        public string? Brand { get; set; }
        [JsonPropertyName("categories_id")]
        public List<int>? CategoriesId { get; set; }
        [JsonPropertyName("tags")] 
        public string? Tags { get; set; }
        [JsonPropertyName("status")]
        public int? Status { get; set; }
        [JsonPropertyName("track_stock")]
        public int? TrackStock { get; set; }
        [JsonPropertyName("initial_stock_level")] 
        public decimal? InitialStockLevel { get; set; }
        [JsonPropertyName("store_id")]
        public int? StoreId { get; set; }
        [JsonPropertyName("low_stock_thershold")]
        public int? LowStockThreshold { get; set; }
    }

    public class DaftraCreateResponse
    {
        [JsonPropertyName("result")] public string Result { get; set; } = string.Empty;
        [JsonPropertyName("code")] public int Code { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
    }
}
