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
    public class StoreService : IStoreService
    {
        private readonly IDaftraStoreClient _daftraStoreClient;

        public StoreService(IDaftraStoreClient daftraStoreClient)
        {
            _daftraStoreClient = daftraStoreClient;
        }
        public async Task<PagedResult<StoreDto>> GetStoresAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default)
        {
            var response = await _daftraStoreClient.GetStoresAsync(page, limit, cancellationToken);

            return new PagedResult<StoreDto>
            {
                Items = response.Data.Select(x => MapToDto(x.Store)).ToList(),
                Page = response.Pagination?.Page ?? page,
                PageCount = response.Pagination?.PageCount ?? 1,
                TotalResults = response.Pagination?.TotalResults ?? response.Data.Count
            };
        }
        public async Task<StoreDto?> GetStoreByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _daftraStoreClient.GetStoreByIdAsync(id, cancellationToken);
            return response is null ? null : MapToDto(response.Data.Store);
        }

        private static StoreDto MapToDto(DaftraStore store) => new()
        {
            Id = store.Id,
            Name = store.Name,
            ShippingAddress = store.ShippingAddress,
            IsPrimary = store.Primary == 1,
            ActiveStatus = store.Active,
            BranchId = store.BranchId
        };
    }
}
