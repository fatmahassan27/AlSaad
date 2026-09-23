using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraProductStock
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("product_id")]
        public string? ProductId { get; set; }

        [JsonPropertyName("store_id")]
        public string? StoreId { get; set; }

        [JsonPropertyName("balance")]
        public decimal? Balance { get; set; }

        [JsonPropertyName("branch_id")]
        public string? BranchId { get; set; }
    }
}
