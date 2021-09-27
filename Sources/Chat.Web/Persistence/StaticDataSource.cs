using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Web.Domain.Models;

namespace Chat.Web.Persistence
{
    public static class StaticDataSource
    {
        private static List<MessageItem> _messageItems = new[]
        {
            new MessageItem("User Server 1", "Hi", DateTime.Now),
            new MessageItem("User Server 2", "There", DateTime.Now - TimeSpan.FromDays(2)),
            new MessageItem("User Server 3", "Milord", DateTime.Now - TimeSpan.FromDays(3))
        }.ToList();

        public static IReadOnlyCollection<MessageItem> GetMessages()
        {
            return _messageItems;
        }
        
        public static MessageItem AddMessageItem(string user, string message)
        {
            var messageItem = new MessageItem(user, message, DateTime.UtcNow);

            _messageItems.Add(messageItem);

            return messageItem;
        }
    }
}
