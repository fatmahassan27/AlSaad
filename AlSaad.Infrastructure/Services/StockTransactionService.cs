using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IDaftraStockTransactionClient _daftraStockTransactionClient;

        public StockTransactionService(IDaftraStockTransactionClient daftraStockTransactionClient)
        {
            _daftraStockTransactionClient = daftraStockTransactionClient;
        }
        public async Task<PagedResult<StockTransactionDto>> GetStockTransactionsAsync(StockTransactionQueryDto query, CancellationToken cancellationToken = default)
        {
            var response = await _daftraStockTransactionClient.GetStockTransactionsAsync(query, cancellationToken);

            return new PagedResult<StockTransactionDto>
            {
                Items = response.Data.Select(x => MapToDto(x.StockTransaction)).ToList(),
                Page = response.Pagination?.Page ?? query.Page,
                PageCount = response.Pagination?.PageCount ?? 1,
                TotalResults = response.Pagination?.TotalResults ?? response.Data.Count
            };
        }
        public async Task<StockTransactionDto?> GetStockTransactionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _daftraStockTransactionClient.GetStockTransactionByIdAsync(id, cancellationToken);
            return response is null ? null : MapToDto(response.Data.StockTransaction);
        }
        private static StockTransactionDto MapToDto(DaftraStockTransaction transaction) => new()
        {
            Id = transaction.Id,
            ProductId = transaction.ProductId,
            StoreId = transaction.StoreId,
            OrderId = transaction.OrderId,
            SourceType = transaction.SourceType,
            TransactionType = transaction.TransactionType,
            Quantity = transaction.Quantity ?? 0,
            Price = transaction.Price,
            PurchasePrice = transaction.PurchasePrice,
            TotalPrice = transaction.TotalPrice,
            CurrencyCode = transaction.CurrencyCode,
            ReceivedDate = DateTime.TryParse(transaction.ReceivedDate, out var date) ? date : null,
            Status = transaction.Status,
            Notes = transaction.Notes
        };
    }
}
