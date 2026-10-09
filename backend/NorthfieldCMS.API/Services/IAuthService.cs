using System.Threading.Tasks;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<OtpResponseDto> SendOtpAsync(ForgotPasswordDto dto);
        Task<OtpResponseDto> VerifyOtpAsync(VerifyOtpDto dto);
        Task<OtpResponseDto> ResetPasswordAsync(ResetPasswordDto dto);
        Task<OtpResponseDto> ResendOtpAsync(ResendOtpDto dto);
    }
}
