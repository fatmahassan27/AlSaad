using AlSaad.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Persistence.Context
{
    public class AppDBContext :IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(u => u.UserName).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(r => r.Description).HasMaxLength(100);
            });
        }
    }
}
