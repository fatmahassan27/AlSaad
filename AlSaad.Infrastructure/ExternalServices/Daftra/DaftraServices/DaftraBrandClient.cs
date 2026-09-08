using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class DaftraBrandClient : GenericDaftraApiClientBase , IDaftraBrandClient
    {
        public DaftraBrandClient(HttpClient httpClient) : base(httpClient) { }
        public Task<DaftraBrandListResponse> GetBrandsAsync(int page = 1, CancellationToken cancellationToken = default)
          => GetListAsync<DaftraBrandListResponse>($"brand/list?page={page}", cancellationToken);
        public async Task<DaftraBrand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync($"brand/{id}", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DaftraBrand>(JsonOptions, cancellationToken);
            }

            if ((int)response.StatusCode == 500)
            {
                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                if (body.Contains("error happened", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }
            }

            response.EnsureSuccessStatusCode(); 
            return null;
        }
    }
}
