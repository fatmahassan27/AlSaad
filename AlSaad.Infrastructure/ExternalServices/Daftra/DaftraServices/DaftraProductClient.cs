using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class DaftraProductApiClient : GenericDaftraApiClientBase, IDaftraProductClient
    {
        public DaftraProductApiClient(HttpClient httpClient) : base(httpClient) { }
      
        public Task<DaftraProductListResponse> GetProductsAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default)
            => GetListAsync<DaftraProductListResponse>($"products.json?page={page}&limit={limit}", cancellationToken);

        public Task<DaftraSingleProductResponse?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
            => GetSingleAsync<DaftraSingleProductResponse>($"products/{id}.json", cancellationToken);
    }
}
