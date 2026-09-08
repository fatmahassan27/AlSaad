using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class StoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShippingAddress { get; set; }
        public bool IsPrimary { get; set; }

        // 0 = Inactive, 1 = Active, 2 = Suspended
        public int ActiveStatus { get; set; }
        public int BranchId { get; set; }
    }
}
