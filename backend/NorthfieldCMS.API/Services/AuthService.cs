using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NorthfieldCMS.API.Data;
using NorthfieldCMS.API.DTOs;
using NorthfieldCMS.API.Models;
using BCrypt.Net;

namespace NorthfieldCMS.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower().Trim());
            if (user == null)
            {
                return new AuthResponseDto { Message = "Invalid email address or user not found." };
            }

            bool isPasswordValid = false;
            try
            {
                isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            }
            catch
            {
                // Fallback check if plain text in legacy fallback scenario
                isPasswordValid = (user.PasswordHash == dto.Password);
            }

            if (!isPasswordValid)
            {
                return new AuthResponseDto { Message = "Invalid password provided." };
            }

            return GenerateAuthResponse(user, "Login successful.");
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower().Trim());
            if (existingUser != null)
            {
                return new AuthResponseDto { Message = "An account with this email already exists." };
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            string roleCapitalized = char.ToUpper(dto.Role[0]) + dto.Role.Substring(1).ToLower();

            var user = new User
            {
                FullName = dto.Name,
                Email = dto.Email.ToLower().Trim(),
                PasswordHash = passwordHash,
                Role = roleCapitalized,
                Department = dto.Department,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return GenerateAuthResponse(user, "Account registered successfully.");
        }

        private AuthResponseDto GenerateAuthResponse(User user, string message)
        {
            var jwtSecret = _config["JwtSettings:Secret"] ?? "NorthfieldCMS_SuperSecretKey_Jwt_Auth_2026_KeyString_32BytesMin!";
            var issuer = _config["JwtSettings:Issuer"] ?? "NorthfieldCMS.API";
            var audience = _config["JwtSettings:Audience"] ?? "NorthfieldCMS.Client";
            var expiryMinutes = double.Parse(_config["JwtSettings:ExpiryMinutes"] ?? "1440");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Department", user.Department ?? "")
            };

            var expiration = DateTime.UtcNow.AddMinutes(expiryMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            string[] nameParts = user.FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string initials = nameParts.Length >= 2 
                ? $"{nameParts[0][0]}{nameParts[1][0]}".ToUpper() 
                : (nameParts.Length == 1 ? $"{nameParts[0][0]}".ToUpper() : "U");

            return new AuthResponseDto
            {
                Token = tokenString,
                Email = user.Email,
                Name = user.FullName,
                Role = user.Role,
                Department = user.Department ?? string.Empty,
                Initials = initials,
                Expiration = expiration,
                Message = message
            };
        }
    }
}
