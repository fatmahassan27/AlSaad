using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.Models
{
    public class DaftraStockTransactionListResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public List<DaftraStockTransactionEnvelope> Data { get; set; } = new();

        [JsonPropertyName("pagination")]
        public DaftraPagination? Pagination { get; set; }

    }
    public class DaftraStockTransactionEnvelope
    {
        [JsonPropertyName("StockTransaction")]
        public DaftraStockTransaction StockTransaction { get; set; } = new();
    }
    public class DaftraStockTransaction
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("store_id")]
        public int StoreId { get; set; }

        [JsonPropertyName("order_id")]
        public int? OrderId { get; set; }

        [JsonPropertyName("source_type")]
        public int SourceType { get; set; }

        [JsonPropertyName("transaction_type")]
        public int TransactionType { get; set; }

        [JsonPropertyName("quantity")]
        public decimal? Quantity { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("purchase_price")]
        public decimal? PurchasePrice { get; set; }

        [JsonPropertyName("total_price")]
        public decimal? TotalPrice { get; set; }

        [JsonPropertyName("currency_code")]
        public string? CurrencyCode { get; set; }

        [JsonPropertyName("received_date")]
        public string? ReceivedDate { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
    }

    public class DaftraSingleStockTransactionResponse
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public DaftraStockTransactionEnvelope Data { get; set; } = new();
    }
}
