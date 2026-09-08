using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
     public class ProductCategoryDto
     {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ParentId { get; set; }
        public string? ParentCategoryName { get; set; }
        public string? ImageUrl { get; set; }
     }
}
