using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthfieldCMS.API.DTOs;
using NorthfieldCMS.API.Services;

namespace NorthfieldCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotService _chatbotService;

        public ChatbotController(IChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequestDto request)
        {
            if (request == null) return BadRequest("Invalid chat request.");

            var response = await _chatbotService.GetChatResponseAsync(request);
            return Ok(response);
        }
    }
}
