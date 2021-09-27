using System;

namespace Chat.Web.Domain.Models
{
    public class MessageItem
    {
        public MessageItem(string user, string message, DateTime createdAt)
        {
            User = user;
            Message = message;
            CreatedAt = createdAt;
        }

        public string User { get; }

        public string Message { get; }

        public DateTime CreatedAt { get; }
    }
}
