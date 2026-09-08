using AlSaad.Application.DTOs;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraStockTransactionClient
    {
        Task<DaftraStockTransactionListResponse> GetStockTransactionsAsync(StockTransactionQueryDto query, CancellationToken cancellationToken = default);
        Task<DaftraSingleStockTransactionResponse?> GetStockTransactionByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
