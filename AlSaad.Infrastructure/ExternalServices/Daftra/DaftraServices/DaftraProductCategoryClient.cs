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
    public class DaftraProductCategoryClient : GenericDaftraApiClientBase, IDaftraProductCategoryClient
    {
        public DaftraProductCategoryClient(HttpClient httpClient) : base(httpClient) { }
        public Task<DaftraProductCategoryListResponse> GetCategoriesAsync(int page = 1, int limit = 20, int? parentId = null, CancellationToken cancellationToken = default)
        {
            var url = $"product_categories.json?page={page}&limit={limit}";
            if (parentId.HasValue)
                url += $"&parent_id={parentId.Value}";

            return GetListAsync<DaftraProductCategoryListResponse>(url, cancellationToken);
        }

        public Task<DaftraSingleProductCategoryResponse?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
            => GetSingleAsync<DaftraSingleProductCategoryResponse>($"product_categories/{id}.json", cancellationToken);
    }
}
