using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public int Type { get; set; } = 1;          
        public string? ProductCode { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? Discount { get; set; }
        public int? DiscountType { get; set; }          
        public string? Brand { get; set; }              
        public List<int>? CategoryIds { get; set; }
        public string? Tags { get; set; }
        public int? Status { get; set; }               
        public bool TrackStock { get; set; }
        public decimal? InitialStockLevel { get; set; }
        public int? StoreId { get; set; }
        public int? LowStockThreshold { get; set; }
    }
}
