using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class RequisitionDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime? Date { get; set; }

        // 1 = Inbound, 2 = Outbound, 3 = Manual Transfer (no effect)
        public int Type { get; set; }

        // 1 = Under Delivery, 3 = Accepted, 4 = Rejected
        public int Status { get; set; }

        public int StoreId { get; set; }
        public int? ToStoreId { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Notes { get; set; }
        public List<RequisitionItemDto> Items { get; set; } = new();
    }
    public class RequisitionItemDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
