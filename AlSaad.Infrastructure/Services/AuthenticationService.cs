using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IRepositories;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private const int RefreshTokenValidDays = 30;
        private const int AccessTokenValidMinutes = 60;

        public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public  async Task<AuthenticationResponseDTO> Register(RegisterDTO request)
        {
            var existing = await _userRepository.GetByEmailAsync(request.Email);
            if (existing != null)
            {
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Unable to register with this email address."
                };
            }
            var user = new User { };
            //{
            //    Email = request.Email.Trim().ToLowerInvariant(),
            //    FullName = request.FullName,
            //    CreatedDate = DateTime.Now,
            //    Password = request.Password,
            //    Role = "Customer",
            //};

            await _userRepository.AddAsync(user);

            var token = _tokenService.GenerateToken(user);

            return new AuthenticationResponseDTO
            {
                Success = true,
                Message = "Registered successfully.",
                Token = token,
            };

        }

        public async Task<AuthenticationResponseDTO> Login(LoginDTO request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || user.Password != request.Password)
            {
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Invalid email or password."
                };
            }

          
            var token = _tokenService.GenerateToken(user);
            return new AuthenticationResponseDTO
            {
                Success = true,
                Message = "Login successful.",
                Token = token,
            };
        }
    }
}
