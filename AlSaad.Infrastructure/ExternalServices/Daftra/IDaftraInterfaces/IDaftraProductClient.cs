using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces
{
    public interface IDaftraProductClient
    {
        Task<DaftraProductListResponse> GetProductsAsync(int page = 1, int limit = 20, CancellationToken cancellationToken = default);
        Task<DaftraSingleProductResponse?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<DaftraCreateResponse> CreateProductAsync(DaftraCreateProductRequest request, CancellationToken cancellationToken = default);
        Task<bool> UpdateProductAsync(int id, DaftraUpdateProductRequest request, CancellationToken cancellationToken = default);
        Task<bool> DeleteProductAsync(int id, CancellationToken cancellationToken = default);
    }
}

