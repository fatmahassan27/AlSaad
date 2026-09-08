using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IRequisitionService
    {
        Task<PagedResult<RequisitionDto>> GetRequisitionsAsync(int page = 1, int? storeId = null, CancellationToken cancellationToken = default);
        Task<RequisitionDto?> GetRequisitionByIdAsync(int id, CancellationToken cancellationToken = default);

    }
}
