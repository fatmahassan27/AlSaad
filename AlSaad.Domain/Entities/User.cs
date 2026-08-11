using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int RoleId { get; private set; }
        [ForeignKey("RoleId")]
        public Role Role { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedDate { get; private set; }
    }
}
