using System.Threading.Tasks;
using NorthfieldCMS.API.DTOs;

namespace NorthfieldCMS.API.Services
{
    public interface IChatbotService
    {
        Task<ChatResponseDto> GetChatResponseAsync(ChatRequestDto request);
    }
}
