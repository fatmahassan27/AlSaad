using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraProductCategoryClient
    {
        Task<DaftraProductCategoryListResponse> GetCategoriesAsync(int page = 1, int limit = 20, int? parentId = null, CancellationToken cancellationToken = default);
        Task<DaftraSingleProductCategoryResponse?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
