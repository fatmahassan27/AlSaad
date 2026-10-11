using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraUpdateProductRequest
    {
        [JsonPropertyName("Product")]
        public DaftraUpdateProductBody Product { get; set; } = new();
    }
    public class DaftraUpdateProductBody
    {
        [JsonPropertyName("name")] 
        public string? Name { get; set; }
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
        [JsonPropertyName("brand")]
        public string? Brand { get; set; }
        [JsonPropertyName("categories_id")]
        public List<int>? CategoriesId { get; set; }
        [JsonPropertyName("status")]
        public int? Status { get; set; }
        [JsonPropertyName("low_stock_thershold")]
        public int? LowStockThreshold { get; set; }
    }
}
