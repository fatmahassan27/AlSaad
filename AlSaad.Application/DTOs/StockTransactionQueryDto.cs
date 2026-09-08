using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class StockTransactionQueryDto
    {
        public int Page { get; set; } = 1;
        public int? Limit { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public string? SourceType { get; set; } 
        public int? BranchId { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
    }
}
