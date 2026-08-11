using AlSaad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Interfaces.IServices
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDTO> Register(RegisterDTO request);
        Task<AuthenticationResponseDTO> Login(LoginDTO request);
    }
}
