using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraProductEnvelope
    {
        [JsonPropertyName("Product")]
        public DaftraProduct Product { get; set; } = new();
    }
}
