using System.Collections.Generic;

namespace Chat.Web.Dtos
{
    public class ChatDto
    {
        public IReadOnlyCollection<MessageItemDto> Messages { get; set; }
    }
}
