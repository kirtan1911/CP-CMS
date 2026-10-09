using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly IEmailService _emailService;
        private static readonly Random _random = new Random();

        public AuthService(ApplicationDbContext db, IConfiguration config, IEmailService emailService)
        {
            _db = db;
            _config = config;
            _emailService = emailService;
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

        public async Task<OtpResponseDto> SendOtpAsync(ForgotPasswordDto dto)
        {
            string cleanEmail = dto.Email.ToLower().Trim();
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == cleanEmail);
            if (user == null)
            {
                return new OtpResponseDto { Success = false, Message = "No registered account found with this email." };
            }

            string otpCode = _random.Next(100000, 999999).ToString();
            DateTime expiresAt = DateTime.UtcNow.AddMinutes(5);

            var existingOtps = await _db.PasswordResetOtps.Where(o => o.Email == cleanEmail && !o.IsUsed).ToListAsync();
            foreach (var old in existingOtps)
            {
                old.IsUsed = true;
            }

            var otpRecord = new PasswordResetOtp
            {
                Email = cleanEmail,
                OtpCode = otpCode,
                ExpiresAt = expiresAt,
                IsUsed = false,
                CreatedAt = DateTime.UtcNow
            };

            _db.PasswordResetOtps.Add(otpRecord);
            await _db.SaveChangesAsync();

            // Send Email via EmailService
            try
            {
                await _emailService.SendOtpEmailAsync(cleanEmail, user.FullName, otpCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AuthService]: Email sending warning: {ex.Message}");
            }

            Console.WriteLine($"[OTP ENGINE]: Generated OTP {otpCode} for {cleanEmail}, valid until {expiresAt}");

            return new OtpResponseDto
            {
                Success = true,
                Message = $"OTP code sent successfully to {cleanEmail}. (Check inbox)",
                DevOtpCode = otpCode
            };
        }

        public async Task<OtpResponseDto> VerifyOtpAsync(VerifyOtpDto dto)
        {
            string cleanEmail = dto.Email.ToLower().Trim();
            string cleanOtp = dto.OtpCode.Trim();

            var otpRecord = await _db.PasswordResetOtps
                .FirstOrDefaultAsync(o => o.Email == cleanEmail && o.OtpCode == cleanOtp && !o.IsUsed && o.ExpiresAt > DateTime.UtcNow);

            if (otpRecord == null)
            {
                return new OtpResponseDto { Success = false, Message = "Invalid or expired OTP code. Please request a new one." };
            }

            return new OtpResponseDto
            {
                Success = true,
                Message = "OTP verified successfully. You may now set a new password."
            };
        }

        public async Task<OtpResponseDto> ResetPasswordAsync(ResetPasswordDto dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
            {
                return new OtpResponseDto { Success = false, Message = "Passwords do not match." };
            }

            string cleanEmail = dto.Email.ToLower().Trim();
            string cleanOtp = dto.OtpCode.Trim();

            var otpRecord = await _db.PasswordResetOtps
                .FirstOrDefaultAsync(o => o.Email == cleanEmail && o.OtpCode == cleanOtp && !o.IsUsed && o.ExpiresAt > DateTime.UtcNow);

            if (otpRecord == null)
            {
                return new OtpResponseDto { Success = false, Message = "Invalid or expired OTP verification session." };
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == cleanEmail);
            if (user == null)
            {
                return new OtpResponseDto { Success = false, Message = "User account not found." };
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            otpRecord.IsUsed = true;

            await _db.SaveChangesAsync();

            return new OtpResponseDto
            {
                Success = true,
                Message = "Password reset successfully! Please login with your new password."
            };
        }

        public async Task<OtpResponseDto> ResendOtpAsync(ResendOtpDto dto)
        {
            return await SendOtpAsync(new ForgotPasswordDto { Email = dto.Email });
        }

        private AuthResponseDto GenerateAuthResponse(User user, string message)
        {
            var jwtSecret = _config["Jwt:Key"] ?? _config["JwtSettings:Secret"] ?? "NorthfieldCMS_SuperSecretKey_Jwt_Auth_2026_KeyString_32BytesMin!";
            var issuer = _config["Jwt:Issuer"] ?? _config["JwtSettings:Issuer"] ?? "CollegeManagementSystem";
            var audience = _config["Jwt:Audience"] ?? _config["JwtSettings:Audience"] ?? "CollegeManagementSystemUsers";
            var expiryMinutes = double.Parse(_config["Jwt:DurationInMinutes"] ?? _config["JwtSettings:ExpiryMinutes"] ?? "1440");

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
