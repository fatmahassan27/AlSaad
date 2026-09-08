using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraRequisitionClient
    {
        Task<DaftraRequisitionListResponse> GetRequisitionsAsync(int page = 1, int? storeId = null, CancellationToken cancellationToken = default);
        Task<DaftraSingleRequisitionResponse?> GetRequisitionByIdAsync(int id, CancellationToken cancellationToken = default);

    }
}
