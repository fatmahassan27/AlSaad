using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class DaftraStoreClient : GenericDaftraApiClientBase , IDaftraStoreClient
    {
        public DaftraStoreClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<DaftraStoreListResponse> GetStoresAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default)
            => GetListAsync<DaftraStoreListResponse>($"stores.json?page={page}&limit={limit}", cancellationToken);

        public Task<DaftraSingleStoreResponse?> GetStoreByIdAsync(int id, CancellationToken cancellationToken = default)
            => GetSingleAsync<DaftraSingleStoreResponse>($"stores/{id}.json", cancellationToken);
    }
}
