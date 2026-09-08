using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraBrandClient
    {
        Task<DaftraBrandListResponse> GetBrandsAsync(int page = 1, CancellationToken cancellationToken = default);
        Task<DaftraBrand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
