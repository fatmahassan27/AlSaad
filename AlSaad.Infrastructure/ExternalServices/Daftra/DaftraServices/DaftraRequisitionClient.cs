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
    public class DaftraRequisitionClient : GenericDaftraApiClientBase,IDaftraRequisitionClient
    {
        public DaftraRequisitionClient(HttpClient httpClient) : base(httpClient) { }


        public Task<DaftraRequisitionListResponse> GetRequisitionsAsync(int page = 1, int? storeId = null, CancellationToken cancellationToken = default)
        {
            var url = $"requisitions.json?page={page}";
            if (storeId.HasValue)
                url += $"&store_id={storeId.Value}";

            return GetListAsync<DaftraRequisitionListResponse>(url, cancellationToken);
        }

        public Task<DaftraSingleRequisitionResponse?> GetRequisitionByIdAsync(int id, CancellationToken cancellationToken = default)
            => GetSingleAsync<DaftraSingleRequisitionResponse>($"requisitions/{id}.json", cancellationToken);
    }
}
