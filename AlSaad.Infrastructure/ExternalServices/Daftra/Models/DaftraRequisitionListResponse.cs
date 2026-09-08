using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraRequisitionListResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public List<DaftraRequisitionEnvelope> Data { get; set; } = new();

        [JsonPropertyName("pagination")]
        public DaftraPagination? Pagination { get; set; }
 
    }
    public class DaftraRequisitionEnvelope
    {
        [JsonPropertyName("Requisition")]
        public DaftraRequisition Requisition { get; set; } = new();
    }
    public class DaftraRequisition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("order_type")]
        public int? OrderType { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("store_id")]
        public int StoreId { get; set; }

        [JsonPropertyName("to_store_id")]
        public int? ToStoreId { get; set; }

        [JsonPropertyName("currency_code")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        // هنظبط الـ fields دي بالظبط بعد ما نشوف رد حقيقي من Postman
        [JsonPropertyName("RequisitionItem")]
        public List<DaftraRequisitionItem> RequisitionItem { get; set; } = new();
    }
    public class DaftraRequisitionItem
    {
        [JsonPropertyName("product_id")]
        public int? ProductId { get; set; }

        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }

        [JsonPropertyName("quantity")]
        public decimal? Quantity { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal? UnitPrice { get; set; }
    }
}
