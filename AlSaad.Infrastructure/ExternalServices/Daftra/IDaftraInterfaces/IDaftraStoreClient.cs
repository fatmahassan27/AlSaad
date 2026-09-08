using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraStoreClient
    {
      Task<DaftraStoreListResponse> GetStoresAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default);
      Task<DaftraSingleStoreResponse?> GetStoreByIdAsync(int id, CancellationToken cancellationToken = default);
       
    }
}
