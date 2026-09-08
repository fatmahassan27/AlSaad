using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraSingleRequisitionResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public DaftraRequisitionEnvelope Data { get; set; } = new();
    }
    public class DaftraSingleProductCategoryData
    {
        [JsonPropertyName("Category")]
        public DaftraProductCategory Category { get; set; } = new();

        [JsonPropertyName("Attachments")]
        public List<object> Attachments { get; set; } = new();
    }
}
