using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class ProductStockDto
    {
        public string? Id { get; set; }

        public string? ProductId { get; set; }

        public string? StoreId { get; set; }

        public decimal? Balance { get; set; }

        public string? BranchId { get; set; }
    }
}
