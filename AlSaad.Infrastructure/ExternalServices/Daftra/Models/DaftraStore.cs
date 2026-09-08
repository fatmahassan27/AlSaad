using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraStore
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("shipping_address")]
        public string? ShippingAddress { get; set; }

        [JsonPropertyName("primary")]
        public int Primary { get; set; }

        [JsonPropertyName("active")]
        public int Active { get; set; }

        [JsonPropertyName("branch_id")]
        public int BranchId { get; set; }
    }
}
