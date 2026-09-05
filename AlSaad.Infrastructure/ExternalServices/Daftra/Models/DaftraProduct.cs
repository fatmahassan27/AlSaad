using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal? UnitPrice { get; set; }

        [JsonPropertyName("buy_price")]
        public decimal? BuyPrice { get; set; }

        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("product_code")]
        public string? ProductCode { get; set; }

        [JsonPropertyName("barcode")]
        public string? Barcode { get; set; }

        [JsonPropertyName("track_stock")]
        public int TrackStock { get; set; }

        [JsonPropertyName("stock_balance")]
        public decimal StockBalance { get; set; }

        // 0 = Active, 1 = Inactive, 2 = Suspended
        [JsonPropertyName("status")]
        public int Status { get; set; }

        // 1 = Product, 2 = Service, 3 = Bundle
        [JsonPropertyName("type")]
        public int? Type { get; set; }
        [JsonPropertyName("ProductCategory")]
        public List<DaftraProductCategory> ProductCategory { get; set; } = new();
    }
}
