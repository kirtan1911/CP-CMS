using System;

namespace NorthfieldCMS.API.DTOs
{
    public class ChatRequestDto
    {
        public string Message { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
    }

    public class ChatResponseDto
    {
        public string Reply { get; set; } = string.Empty;
        public string Timestamp { get; set; } = DateTime.Now.ToString("HH:mm");
        public bool Success { get; set; } = true;
    }
}
