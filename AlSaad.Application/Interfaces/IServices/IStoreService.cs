using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IStoreService
    {
        Task<PagedResult<StoreDto>> GetStoresAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default);
        Task<StoreDto?> GetStoreByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
