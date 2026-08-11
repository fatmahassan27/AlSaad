using AlSaad.Application.Interfaces.IRepositories;
using AlSaad.Domain.Entities;
using AlSaad.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Persistence.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var normalized = email.Trim().ToLowerInvariant();
            return await _dbContext.Users.FirstOrDefaultAsync(a => a.Email == normalized);
        }

        public  async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            var exsistingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (exsistingUser == null)
            {
                return;
            }
            else
                _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
