using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraUnitTemplateClient
    {
        Task<DaftraUnitTemplateListResponse> GetUnitTemplatesAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<DaftraUnitTemplate?> GetUnitTemplateByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
