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
    public class DaftraApiClient : IDaftraApiClient
    {
        private readonly HttpClient _httpClient;

        public DaftraApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //allow read numbers from string in json response
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        public async Task<DaftraProductListResponse> GetProductsAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"products.json?page={page}&limit={limit}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<DaftraProductListResponse>(_jsonOptions, cancellationToken);
            return result ?? new DaftraProductListResponse();
        }

        public async Task<DaftraSingleProductResponse?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"products/{id}.json", cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<DaftraSingleProductResponse>(_jsonOptions, cancellationToken);
        }
    }
}
