using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IStockTransactionService
    {
        Task<PagedResult<StockTransactionDto>> GetStockTransactionsAsync(StockTransactionQueryDto query, CancellationToken cancellationToken = default);
        Task<StockTransactionDto?> GetStockTransactionByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
