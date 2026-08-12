using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }    
        public string CustomPassword { get; set; }

    }
}
