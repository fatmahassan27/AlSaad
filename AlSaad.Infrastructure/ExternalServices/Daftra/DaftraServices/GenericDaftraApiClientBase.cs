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
    public class GenericDaftraApiClientBase
    {
        protected readonly HttpClient HttpClient;

        protected static readonly JsonSerializerOptions JsonOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        protected GenericDaftraApiClientBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        protected async Task<TResponse> GetListAsync<TResponse>(string url, CancellationToken cancellationToken)
           where TResponse : new()
        {
            var response = await HttpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
            return result ?? new TResponse();
        }
        protected async Task<TResponse?> GetSingleAsync<TResponse>(string url, CancellationToken cancellationToken)
           where TResponse : class
        {
            var response = await HttpClient.GetAsync(url, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions, cancellationToken);
        }
    }
}
