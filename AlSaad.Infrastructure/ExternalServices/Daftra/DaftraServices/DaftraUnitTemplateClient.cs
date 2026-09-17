using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.DaftraServices
{
    public class DaftraUnitTemplateClient : GenericDaftraApiClientBase , IDaftraUnitTemplateClient
    {
        public DaftraUnitTemplateClient(HttpClient httpClient) : base(httpClient) { }

        public Task<DaftraUnitTemplateListResponse> GetUnitTemplatesAsync(int page = 1, CancellationToken cancellationToken = default)
            => GetListAsync<DaftraUnitTemplateListResponse>($"unit_template/list?page={page}", cancellationToken);

        public Task<DaftraUnitTemplate?> GetUnitTemplateByIdAsync(int id, CancellationToken cancellationToken = default)
            => GetSingleAsync<DaftraUnitTemplate>($"unit_template/{id}", cancellationToken);
    
    }
}
