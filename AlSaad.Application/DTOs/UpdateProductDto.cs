using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class UpdateProductDto
    {
        [StringLength(255, MinimumLength = 1)]
        public string? Name { get; set; }
        public string? ProductCode { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? BuyPrice { get; set; }
        public string? Brand { get; set; }
        public List<int>? CategoryIds { get; set; }

        [Range(0, 2)]
        public int? Status { get; set; }            // 0 نشط, 1 غير نشط, 2 موقوف

        public int? LowStockThreshold { get; set; }
    }
}
