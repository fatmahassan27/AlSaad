using AlSaad.Application.DTOs;
using AlSaad.Application.Interfaces.IServices;
using AlSaad.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ITokenService _tokenService;
      
        public AuthenticationService(ITokenService tokenService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public  async Task<AuthenticationResponseDTO> Register(RegisterDTO request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Unable to register with this email address."
                };
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Unable to register with this Role."
                };

            var user = new ApplicationUser 
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
            };

            var createResult = await _userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Unable to register with user"
                };
            await _userManager.AddToRoleAsync(user, "Admin");

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
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Invalid User."
                };
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                return new AuthenticationResponseDTO
                {
                    Success = false,
                    Message = "Invalid password."
                };
            var roles = await _userManager.GetRolesAsync(user);
            var roleName = roles.FirstOrDefault() ?? "Admin";

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
