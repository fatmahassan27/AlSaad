using AlSaad.Application.DTOs;
using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class DaftraStockTransactionClient : GenericDaftraApiClientBase, IDaftraStockTransactionClient
    {
        public DaftraStockTransactionClient(HttpClient httpClient) : base(httpClient) { }

        public Task<DaftraStockTransactionListResponse> GetStockTransactionsAsync(StockTransactionQueryDto query, CancellationToken cancellationToken = default)
        {
            var url = BuildListUrl(query);
            return GetListAsync<DaftraStockTransactionListResponse>(url, cancellationToken);
        }
        public Task<DaftraSingleStockTransactionResponse?> GetStockTransactionByIdAsync(int id, CancellationToken cancellationToken = default)
           => GetSingleAsync<DaftraSingleStockTransactionResponse>($"stock_transactions/{id}.json", cancellationToken);

        private static string BuildListUrl(StockTransactionQueryDto query)
        {
            var sb = new StringBuilder($"stock_transactions.json?page={query.Page}");

            if (query.Limit.HasValue) sb.Append($"&limit={query.Limit.Value}");
            if (query.ProductId.HasValue) sb.Append($"&product_id={query.ProductId.Value}");
            if (query.StoreId.HasValue) sb.Append($"&store_id={query.StoreId.Value}");
            if (query.BranchId.HasValue) sb.Append($"&branch_id={query.BranchId.Value}");
            if (!string.IsNullOrWhiteSpace(query.SourceType)) sb.Append($"&source_type={query.SourceType}");
            if (!string.IsNullOrWhiteSpace(query.DateFrom)) sb.Append($"&date_from={query.DateFrom}");
            if (!string.IsNullOrWhiteSpace(query.DateTo)) sb.Append($"&date_to={query.DateTo}");

            return sb.ToString();
        }
    }
}
