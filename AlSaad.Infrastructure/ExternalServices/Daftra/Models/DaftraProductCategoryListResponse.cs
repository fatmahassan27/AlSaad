using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraProductCategoryListResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public List<DaftraProductCategoryEnvelope> Data { get; set; } = new();

        [JsonPropertyName("pagination")]
        public DaftraPagination? Pagination { get; set; }
    }
    public class DaftraProductCategoryEnvelope
    {
        [JsonPropertyName("CategoriesCategory")]
        public DaftraProductCategory ProductCategory { get; set; } = new();
    }
   
}
