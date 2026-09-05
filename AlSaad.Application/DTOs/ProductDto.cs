using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public bool InStock { get; set; }
        public decimal StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int TotalResults { get; set; }
    }
}
