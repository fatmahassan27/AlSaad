using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class ProductCategoryDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryType { get; set; }
        public string? ParentId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? Image { get; set; }
        public string? MacAddress { get; set; }
        public string? BranchId { get; set; }
        public string? Status { get; set; }
    }
}
