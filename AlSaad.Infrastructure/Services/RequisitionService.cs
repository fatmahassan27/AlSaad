using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Infrastructure.ExternalServices.Daftra.IDaftraInterfaces;
using AlSaad.Infrastructure.ExternalServices.Daftra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.Services
{
    public class RequisitionService : IRequisitionService
    {
        private readonly IDaftraRequisitionClient _daftraRequisitionClient;

        public RequisitionService(IDaftraRequisitionClient daftraRequisitionClient)
        {
            _daftraRequisitionClient = daftraRequisitionClient;
        }

        public async Task<PagedResult<RequisitionDto>> GetRequisitionsAsync(int page = 1, int? storeId = null, CancellationToken cancellationToken = default)
        {
            var response = await _daftraRequisitionClient.GetRequisitionsAsync(page, storeId, cancellationToken);

            return new PagedResult<RequisitionDto>
            {
                Items = response.Data.Select(x => MapToDto(x.Requisition)).ToList(),
                Page = response.Pagination?.Page ?? page,
                PageCount = response.Pagination?.PageCount ?? 1,
                TotalResults = response.Pagination?.TotalResults ?? response.Data.Count
            };
        }
        public async Task<RequisitionDto?> GetRequisitionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await _daftraRequisitionClient.GetRequisitionByIdAsync(id, cancellationToken);
            return response is null ? null : MapToDto(response.Data.Requisition);
        }
        private static RequisitionDto MapToDto(DaftraRequisition requisition) => new()
        {
            Id = requisition.Id,
            Number = requisition.Number ?? string.Empty,
            Date = DateTime.TryParse(requisition.Date, out var date) ? date : null,
            Type = requisition.Type,
            Status = requisition.Status,
            StoreId = requisition.StoreId,
            ToStoreId = requisition.ToStoreId,
            CurrencyCode = requisition.CurrencyCode,
            Notes = requisition.Notes,
            Items = requisition.RequisitionItem.Select(i => new RequisitionItemDto
            {
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                Quantity = i.Quantity ?? 0,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }
}

