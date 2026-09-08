using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraStoreListResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public List<DaftraStoreEnvelope> Data { get; set; } = new();

        [JsonPropertyName("pagination")]
        public DaftraPagination? Pagination { get; set; }
    }
    public class DaftraStoreEnvelope
    {
        [JsonPropertyName("Store")]
        public DaftraStore Store { get; set; } = new();
    }

}
