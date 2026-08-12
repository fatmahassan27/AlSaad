using AlSaad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);

    }

}
