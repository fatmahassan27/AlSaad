using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraUnitTemplate
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("template_name")]
        public string TemplateName { get; set; } = string.Empty;

        [JsonPropertyName("active")]
        public int Active { get; set; }

        [JsonPropertyName("main_unit_name")]
        public string MainUnitName { get; set; } = string.Empty;

        [JsonPropertyName("unit_small_name")]
        public string? UnitSmallName { get; set; }

        // مش موجودة في الـ List، بترجع بس في الـ Single
        [JsonPropertyName("unit_templates_unit_factors")]
        public List<DaftraUnitFactor>? UnitTemplatesUnitFactors { get; set; }
    }
    public class DaftraUnitFactor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("factor_name")]
        public string FactorName { get; set; } = string.Empty;

        [JsonPropertyName("factor")]
        public decimal Factor { get; set; }

        [JsonPropertyName("small_name")]
        public string? SmallName { get; set; }
    }
}
